using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using System.Windows.Media;
using TenkiApp.Model;

namespace TenkiApp.ViewModel {
    public class WeatherViewModel : INotifyPropertyChanged {
        private readonly WeatherService _service = new WeatherService();

        public ObservableCollection<string> PrefectureList { get; } = new ObservableCollection<string>
        {
            "北海道","青森県","岩手県","宮城県","秋田県","山形県","福島県","茨城県","栃木県","群馬県",
            "埼玉県","千葉県","東京都","神奈川県","新潟県","富山県","石川県","福井県","山梨県","長野県",
            "岐阜県","静岡県","愛知県","三重県","滋賀県","京都府","大阪府","兵庫県","奈良県","和歌山県",
            "鳥取県","島根県","岡山県","広島県","山口県","徳島県","香川県","愛媛県","高知県",
            "福岡県","佐賀県","長崎県","熊本県","大分県","宮崎県","鹿児島県","沖縄県"
        };

        private string _selectedPrefecture = "東京都";
        public string SelectedPrefecture { get => _selectedPrefecture; set { _selectedPrefecture = value; OnPropertyChanged(); } }

        // 天気表示用プロパティ
        public string Time { get; set; } = "-";
        public string Temperature { get; set; } = "-";
        public string WindSpeed { get; set; } = "-";
        public string Humidity { get; set; } = "-";
        public string WeatherEmoji { get; set; } = "☀";
        public Brush BackgroundBrush { get; set; } = Brushes.LightSkyBlue;

        public ICommand FetchWeatherCommand { get; }

        // 47都道府県緯度経度
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
            FetchWeatherCommand = new RelayCommand(async (param) => {
                string prefecture = SelectedPrefecture;
                int index = Array.IndexOf(PrefectureList.ToArray(), prefecture);
                var (lat, lon) = PrefectureToLatLon[index];

                try {
                    var data = await _service.GetWeatherAsync(lat, lon);
                    if (data?.Current != null) {
                        Temperature = data.Current.Temperature.ToString("0.0");
                        WindSpeed = data.Current.WindSpeed.ToString("0.0");
                        Time = data.Current.Time;

                        WeatherEmoji = data.Current.WeatherCode switch {
                            0 => "☀",
                            1 or 2 or 3 => "⛅",
                            61 or 63 or 65 => "🌧",
                            71 or 73 or 75 => "❄",
                            95 or 96 => "⚡",
                            _ => "🌈"
                        };

                        BackgroundBrush = data.Current.WeatherCode switch {
                            0 => Brushes.LightSkyBlue,
                            1 or 2 or 3 => Brushes.LightGray,
                            61 or 63 or 65 => Brushes.LightBlue,
                            71 or 73 or 75 => Brushes.WhiteSmoke,
                            95 or 96 => Brushes.LightYellow,
                            _ => Brushes.LightGreen
                        };

                        OnPropertyChanged(nameof(Temperature));
                        OnPropertyChanged(nameof(WindSpeed));
                        OnPropertyChanged(nameof(Time));
                        OnPropertyChanged(nameof(WeatherEmoji));
                        OnPropertyChanged(nameof(BackgroundBrush));
                    }
                }
                catch {
                    Temperature = WindSpeed = Time = "-";
                    WeatherEmoji = "❓";
                    BackgroundBrush = Brushes.Gray;
                    OnPropertyChanged(nameof(Temperature));
                    OnPropertyChanged(nameof(WindSpeed));
                    OnPropertyChanged(nameof(Time));
                    OnPropertyChanged(nameof(WeatherEmoji));
                    OnPropertyChanged(nameof(BackgroundBrush));
                }
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged([CallerMemberName] string name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public class RelayCommand : ICommand {
        private readonly Action<object> _execute;
        private readonly Func<object, bool> _canExecute;

        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null) {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter) => _canExecute?.Invoke(parameter) ?? true;

        public void Execute(object parameter) => _execute(parameter);

        public event EventHandler CanExecuteChanged {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
