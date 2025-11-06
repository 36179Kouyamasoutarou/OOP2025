using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Exercise01_Wpf {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e) {
            TextArea.Text = await TextRenderSample.ReadTextAsync("吾輩は猫である");
        }
    }

    //非同期のファイル読み込み処理
    static class TextReaderSample {
        public static async Task<string>ReadTextAsync(string filePath) {

        }
    }
}