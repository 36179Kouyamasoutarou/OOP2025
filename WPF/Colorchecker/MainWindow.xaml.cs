using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ColorChecker {

    public partial class MainWindow : Window {
        public string ColorName { get; private set; }
        public MainWindow() {
            InitializeComponent();
            DataContext = GetColorList();
        }

        private MyColor[] GetColorList() {
            return typeof(Colors).GetProperties(BindingFlags.Public | BindingFlags.Static)
                .Select(i => new MyColor() { Color = (Color)i.GetValue(null), Name = i.Name }).ToArray();
        }

        private void Slider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e) {
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;
            Color color = Color.FromRgb(r, g, b);
            Brush brush = new SolidColorBrush(color);
            colorArea.Background = brush;
        }

        private void colorSelectComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            var comboBox = (ComboBox)sender;

            if (comboBox.SelectedItem is MyColor comboSelectMyColor) {
                setSliderValue(comboSelectMyColor.Color);
            } else {
                // SelectedItemがnullの時は何もしない←エラー回避
            }
        }

        private void setSliderValue(Color color) {
            rSlider.Value = color.R;
            gSlider.Value = color.G;
            bSlider.Value = color.B;
        }

        private void stockButton_Click(object sender, RoutedEventArgs e) {
            byte r = (byte)rSlider.Value;
            byte g = (byte)gSlider.Value;
            byte b = (byte)bSlider.Value;
            Color currentColor = Color.FromRgb(r, g, b);
            foreach (var item in stockedColorsListBox.Items) {
                if (item is MyColor existingColor && existingColor.Color == currentColor) {
                    MessageBox.Show("すでに登録されています。", "重複", MessageBoxButton.OK, MessageBoxImage.Information);
                    return;
                }
            }

            var matchedColor = GetColorList().FirstOrDefault(c => c.Color == currentColor);
            string colorName = matchedColor != null
                ? matchedColor.Name
                : $"R:{r} G:{g} B:{b}";
            stockedColorsListBox.Items.Add(new MyColor { Color = currentColor, Name = colorName });
        }

        private void stockedColorsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (stockedColorsListBox.SelectedItem is MyColor selectedColor) {
                // スライダーに色をセットする
                setSliderValue(selectedColor.Color);

                // 色エリアの背景を更新
                colorArea.Background = new SolidColorBrush(selectedColor.Color);

                // ComboBoxの選択も合わせたい場合
                var comboColor = GetColorList().FirstOrDefault(c => c.Color == selectedColor.Color);

                if (comboColor != null) {
                    colorSelectComboBox.SelectedItem = comboColor;
                } else {
                    colorSelectComboBox.SelectedItem = null;
                }
            } else {
                //何もしない
            }
        }

    }
}
