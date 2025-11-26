using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using TenkiApp.Model;

namespace TenkiApp.ViewModel {

    // 💡 NEW: 時間別予報表示用アイテム
    public class HourlyForecastItem {
        public string Time { get; set; }     // 例: 15時
        public string Emoji { get; set; }    // 天気アイコン
        public string Temperature { get; set; } // 例: 15℃
        public string RainChance { get; set; } // 例: 30%
    }

    public class WeatherViewModel : INotifyPropertyChanged {
        private readonly WeatherService _service = new WeatherService();
        private DateTime _currentTime = DateTime.Now;

        // 都道府県リスト (変更なし)
        public ObservableCollection<string> PrefectureList { get; } = new ObservableCollection<string>
        {
             "北海道","青森県","岩手県","宮城県","秋田県","山形県","福島県","茨城県","栃木県","群馬県",
             "埼玉県","千葉県","東京都","神奈川県","新潟県","富山県","石川県","福井県","山梨県","長野県",
             "岐阜県","静岡県","愛知県","三重県","滋賀県","京都府","大阪府","兵庫県","奈良県","和歌山県",
             "鳥取県","島根県","岡山県","広島県","山口県","徳島県","香川県","愛媛県","高知県",
             "福岡県","佐賀県","長崎県","熊本県","大分県","宮崎県","鹿児島県","沖縄県"
        };

        // 💡 NEW: 時間別予報のコレクション
        public ObservableCollection<HourlyForecastItem> HourlyForecast { get; } = new ObservableCollection<HourlyForecastItem>();

        // --- バインド用プロパティ --- (変更なし)
        private string _selectedPrefecture = "東京都";
        public string SelectedPrefecture {
            get => _selectedPrefecture;
            set {
                if (_selectedPrefecture != value) {
                    _selectedPrefecture = value;
                    OnPropertyChanged();
                    if (FetchWeatherCommand.CanExecute(null)) {
                        FetchWeatherCommand.Execute(null);
                    }
                }
            }
        }
        public string DateText { get; set; } = DateTime.Now.ToString("M月d日 (ddd)");
        public string Time { get; set; } = "--:--";
        public string Temperature { get; set; } = "--";
        public string ApparentTemperature { get; set; } = "-";
        public string TempMax { get; set; } = "-";
        public string TempMin { get; set; } = "-";
        public string WindSpeed { get; set; } = "-";
        public string WindDirectionEmoji { get; set; } = "🧭";
        public string Humidity { get; set; } = "-";
        public string Precipitation { get; set; } = "-";
        public string WeatherEmoji { get; set; } = "🌤";
        public string WeatherDescription { get; set; } = "Ready";
        public string TomorrowTempMax { get; set; } = "-";
        public string TomorrowTempMin { get; set; } = "-";
        public string TomorrowWeatherEmoji { get; set; } = "-";
        private Brush _backgroundBrush;
        public Brush BackgroundBrush { get => _backgroundBrush ?? Brushes.LightSkyBlue; set { _backgroundBrush = value; OnPropertyChanged(); } }
        private bool _isBusy;
        public bool IsBusy { get => _isBusy; set { _isBusy = value; OnPropertyChanged(); } }
        public ICommand FetchWeatherCommand { get; }

        private readonly (double lat, double lon)[] PrefectureToLatLon = new (double, double)[]
        {
             (43.06417,141.34694),(40.82444,140.74),(39.70361,141.1525),(38.26889,140.87194),
             (39.71861,140.1025),(38.24056,140.36333),(37.75,140.46778),(36.34139,140.44667),
             (36.56583,139.88361),(36.39111,139.06083),(35.85694,139.64889),(35.605,140.12333),
             (35.68944,139.69167),(35.44778,139.6425),(37.90222,139.02361),(36.69528,137.21139),
             (36.59444,136.62556),(36.06528,136.22194),(35.66389,138.56833),(36.65139,138.18111),
             (35.39111,136.72222),(34.97694,138.38306),(35.18028,136.90667),(34.73028,136.50861),
             (35.00444,135.86833),(35.02139,135.75556),(34.68639,135.52),(34.69139,135.18306),
             (34.68528,135.83278),(34.22611,135.1675),(35.50361,134.23833),(35.47222,133.05056),
             (34.66167,133.93444),(34.39639,132.45944),(34.18583,131.47139),(34.06583,134.55944),
             (34.34028,134.04333),(33.84167,132.76611),(33.55972,133.53111),(33.60639,130.41806),
             (33.24944,130.29889),(32.74472,129.87361),(32.78972,130.74167),(33.23806,131.6125),
             (31.91111,131.42361),(31.56028,130.55806)
        };

        public WeatherViewModel() {
            UpdateBackground(0, _currentTime);

            FetchWeatherCommand = new RelayCommand(async (param) => {
                IsBusy = true;
                try {
                    int index = Array.IndexOf(PrefectureList.ToArray(), SelectedPrefecture);
                    if (index < 0 || index >= PrefectureToLatLon.Length) return;

                    var (lat, lon) = PrefectureToLatLon[index];
                    var data = await _service.GetWeatherAsync(lat, lon);

                    if (data?.Current != null) {
                        // 1. 現在の天気データ (既存処理)
                        Temperature = data.Current.Temperature?.ToString("0") ?? "--";
                        ApparentTemperature = data.Current.ApparentTemperature?.ToString("0") ?? "-";
                        WindSpeed = data.Current.WindSpeed?.ToString("0.0") ?? "-";
                        Humidity = data.Current.Humidity?.ToString() ?? "-";
                        Precipitation = data.Current.Precipitation?.ToString("0.0") ?? "-";

                        if (data.Current.WindDirection.HasValue) {
                            WindDirectionEmoji = GetWindDirectionEmoji(data.Current.WindDirection.Value);
                        } else {
                            WindDirectionEmoji = "🧭";
                        }

                        if (DateTime.TryParse(data.Current.Time, out DateTime dt)) {
                            _currentTime = dt;
                            Time = dt.ToString("HH:mm");
                            DateText = dt.ToString("M月d日 (ddd)");
                        }

                        int weatherCode = data.Current.WeatherCode ?? 3;
                        UpdateWeatherIconAndDesc(weatherCode);

                        // 2. 日次データ (既存処理)
                        if (data.Daily != null && data.Daily.TemperatureMax.Count > 0) {
                            TempMax = data.Daily.TemperatureMax[0].ToString("0");
                            TempMin = data.Daily.TemperatureMin[0].ToString("0");
                        }

                        // 3. 明日の日次データ (既存処理)
                        if (data.Daily != null && data.Daily.TemperatureMax.Count > 1) {
                            TomorrowTempMax = data.Daily.TemperatureMax[1].ToString("0");
                            TomorrowTempMin = data.Daily.TemperatureMin[1].ToString("0");
                            if (data.Daily.WeatherCode.Count > 1) {
                                TomorrowWeatherEmoji = GetWeatherEmoji(data.Daily.WeatherCode[1]);
                            }
                        }

                        // 4. 時間別データ処理 (Hourly) 💡 NEW
                        HourlyForecast.Clear();
                        if (data.Hourly != null && data.Hourly.Time.Count > 0) {

                            int startIndex = 0;
                            // APIのデータリストから、現在時刻に最も近い未来のデータを探す
                            for (int i = 0; i < data.Hourly.Time.Count; i++) {
                                // 現在時刻の30分前より未来の時刻を見つけたら、そこを開始インデックスとする
                                if (DateTime.TryParse(data.Hourly.Time[i], out DateTime hourlyTime) && hourlyTime > _currentTime.AddMinutes(-30)) {
                                    startIndex = i;
                                    break;
                                }
                            }

                            // 開始インデックスから8時間分をコレクションに追加
                            for (int i = startIndex; i < startIndex + 8 && i < data.Hourly.Time.Count; i++) {
                                if (DateTime.TryParse(data.Hourly.Time[i], out DateTime hourlyTime)) {
                                    HourlyForecast.Add(new HourlyForecastItem {
                                        Time = hourlyTime.ToString("H時"),
                                        Emoji = GetWeatherEmoji(data.Hourly.WeatherCode[i]),
                                        Temperature = data.Hourly.Temperature[i].ToString("0") + "℃",
                                        RainChance = data.Hourly.PrecipitationProbability[i] + "%"
                                    });
                                }
                            }
                        }

                        // 5. 背景更新
                        UpdateBackground(weatherCode, _currentTime);

                        RefreshUI();
                    }
                }
                catch (Exception ex) {
                    System.Diagnostics.Debug.WriteLine($"ViewModel Data Handle Error: {ex.Message}");
                    // ... (エラー時の処理は省略) ...
                    UpdateBackground(999, _currentTime);
                    RefreshUI();
                }
                finally {
                    IsBusy = false;
                }
            });
        }

        // --- ヘルパーメソッド (変更なし) ---

        private string GetWeatherEmoji(int code) => code switch {
            0 => "☀",
            1 => "🌤",
            2 => "⛅",
            3 => "☁",
            45 or 48 => "🌫",
            51 or 53 or 55 => "💧",
            61 or 63 or 65 => "☔",
            71 or 73 or 75 => "☃",
            80 or 81 or 82 => "🌧",
            95 or 96 or 99 => "⚡",
            _ => "🌈"
        };
        // ... (他のヘルパーメソッド、INotifyPropertyChangedの実装は変更なし) ...

        private void UpdateWeatherIconAndDesc(int code) {
            WeatherEmoji = GetWeatherEmoji(code);
            WeatherDescription = code switch {
                0 => "快晴",
                1 => "晴れ",
                2 => "一部曇り",
                3 => "曇り",
                45 or 48 => "霧",
                51 or 53 or 55 => "霧雨",
                61 or 63 or 65 => "雨",
                71 or 73 or 75 => "雪",
                80 or 81 or 82 => "にわか雨",
                95 or 96 or 99 => "雷雨",
                _ => "その他"
            };
        }

        private string GetWindDirectionEmoji(int direction) {
            if (direction >= 337.5 || direction < 22.5) return "⬇️北";
            if (direction >= 22.5 && direction < 67.5) return "↙️北東";
            if (direction >= 67.5 && direction < 112.5) return "⬅️東";
            if (direction >= 112.5 && direction < 157.5) return "↖️南東";
            if (direction >= 157.5 && direction < 202.5) return "⬆️南";
            if (direction >= 202.5 && direction < 247.5) return "↗️南西";
            if (direction >= 247.5 && direction < 292.5) return "➡️西";
            if (direction >= 292.5 && direction < 337.5) return "↘️北西";
            return "🧭風向不明";
        }

        private void UpdateBackground(int code, DateTime time) {
            bool isDay = time.Hour >= 6 && time.Hour < 18;
            Color startColor;
            Color endColor;

            if (code == 999) { // エラー
                startColor = (Color)ColorConverter.ConvertFromString("#FF1D0000");
                endColor = (Color)ColorConverter.ConvertFromString("#FF4D2D2D");
            } else if (!isDay) { // 夜間
                switch (code) {
                    case 0 or 1:
                        startColor = (Color)ColorConverter.ConvertFromString("#FF0F2027");
                        endColor = (Color)ColorConverter.ConvertFromString("#FF2C5364");
                        break;
                    case 61 or 63 or 65 or 80 or 81 or 82:
                        startColor = (Color)ColorConverter.ConvertFromString("#FF334d50");
                        endColor = (Color)ColorConverter.ConvertFromString("#FF518b8f");
                        break;
                    default:
                        startColor = (Color)ColorConverter.ConvertFromString("#FF3A445C");
                        endColor = (Color)ColorConverter.ConvertFromString("#FF5B657F");
                        break;
                }
            } else { // 昼間
                switch (code) {
                    case 0 or 1:
                        startColor = (Color)ColorConverter.ConvertFromString("#FF4E54C8");
                        endColor = (Color)ColorConverter.ConvertFromString("#FF8F94FB");
                        break;
                    case 2 or 3:
                        startColor = (Color)ColorConverter.ConvertFromString("#FF757F9A");
                        endColor = (Color)ColorConverter.ConvertFromString("#FFD7DDE8");
                        break;
                    case 61 or 63 or 65:
                        startColor = (Color)ColorConverter.ConvertFromString("#FF2C3E50");
                        endColor = (Color)ColorConverter.ConvertFromString("#FF4CA1AF");
                        break;
                    case 95 or 96 or 99:
                        startColor = (Color)ColorConverter.ConvertFromString("#FF141E30");
                        endColor = (Color)ColorConverter.ConvertFromString("#FF243B55");
                        break;
                    default:
                        startColor = (Color)ColorConverter.ConvertFromString("#FF56CCF2");
                        endColor = (Color)ColorConverter.ConvertFromString("#FF2F80ED");
                        break;
                }
            }

            BackgroundBrush = new LinearGradientBrush(startColor, endColor, 90.0);
        }

        private void RefreshUI() {
            OnPropertyChanged(nameof(Temperature));
            OnPropertyChanged(nameof(ApparentTemperature));
            OnPropertyChanged(nameof(WindSpeed));
            OnPropertyChanged(nameof(WindDirectionEmoji));
            OnPropertyChanged(nameof(Humidity));
            OnPropertyChanged(nameof(Precipitation));
            OnPropertyChanged(nameof(WeatherEmoji));
            OnPropertyChanged(nameof(WeatherDescription));
            OnPropertyChanged(nameof(TempMax));
            OnPropertyChanged(nameof(TempMin));
            OnPropertyChanged(nameof(TomorrowTempMax));
            OnPropertyChanged(nameof(TomorrowTempMin));
            OnPropertyChanged(nameof(TomorrowWeatherEmoji));
            OnPropertyChanged(nameof(Time));
            OnPropertyChanged(nameof(DateText));
            OnPropertyChanged(nameof(BackgroundBrush));
            // 💡 NEW: 時間別予報の変更を通知
            OnPropertyChanged(nameof(HourlyForecast));
        }

        // --- INotifyPropertyChanged & RelayCommand 実装 (変更なし) ---
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class RelayCommand : ICommand {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null) { _execute = execute; _canExecute = canExecute; }
        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;
        public void Execute(object parameter) => _execute(parameter);
        public event EventHandler CanExecuteChanged { add { CommandManager.RequerySuggested += value; } remove { CommandManager.RequerySuggested -= value; } }
    }
}