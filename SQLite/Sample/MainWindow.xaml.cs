using Sample.Data;
using SQLite;
using System;
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

namespace Sample {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private List<Person> _persons = new List<Person>();
        public MainWindow() {
            InitializeComponent();

            //_persons.Add(new Person { Id = 10, Name = "岩村ベジタブルタロウ", Phone = "4554" });
            //_persons.Add(new Person { Id = 12, Name = "岩村ベジタブルタロウ", Phone = "4554" });
            //_persons.Add(new Person { Id = 13, Name = "岩村ベジタブルタロウ", Phone = "4554" });

            PersonListView.ItemsSource = _persons;

        }

        private void SaveButton_Click(object sender, RoutedEventArgs e) {
            var person = new Person() {
                Name = NameTextBox.Text,
                Phone = PhoneTextBox.Text,
            };


            using(var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Person>();
                connection.Insert(person);
            }


        }

        private void ReadButton_Click(object sender, RoutedEventArgs e) {
            

            using (var connection = new SQLiteConnection(App.databasePath)) {
                connection.CreateTable<Person>();
                var persons = connection.Table<Person>().ToList();

            }
        }
    }
}