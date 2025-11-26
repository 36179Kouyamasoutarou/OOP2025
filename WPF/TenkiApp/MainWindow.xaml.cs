using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Animation;

namespace TenkiApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            // アプリ起動時にデータを取得させる（初期表示：東京）
            if (DataContext is ViewModel.WeatherViewModel vm) {
                if (vm.FetchWeatherCommand.CanExecute(null)) {
                    vm.FetchWeatherCommand.Execute(null);
                }
            }

            // フェードインアニメーション開始
            if (Resources.Contains("LoadAnimation") && Resources["LoadAnimation"] is Storyboard sb) {
                sb.Begin();
            }
        }

        // ウィンドウをドラッグできるようにする処理
        private void Grid_MouseDown(object sender, MouseButtonEventArgs e) {
            if (e.LeftButton == MouseButtonState.Pressed) {
                this.DragMove();
            }
        }

        // 閉じるボタンの処理
        private void CloseButton_Click(object sender, RoutedEventArgs e) {
            this.Close();
        }
    }
}