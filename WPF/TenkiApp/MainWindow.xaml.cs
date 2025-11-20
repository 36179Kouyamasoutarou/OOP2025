using System.Windows;
using System.Windows.Media.Animation;

namespace TenkiApp {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e) {
            var sb = (Storyboard)Resources["CardFadeInStoryboard"];
            sb.Begin(MainCard);
        }
    }
}
