using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using lab6.Core.Controllers;
using lab6.Core.Models;

namespace lab6.Core.View
{
    /// <summary>
    /// Логика взаимодействия для LogInPage.xaml
    /// </summary>
    public partial class AddCinemaPage : Page
    {
        public AddCinemaPage()
        {
            InitializeComponent();
        }

        private void AddCinemaButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var cinema = new Cinema
                (
                    CinemaNameTextBox.Text,
                    StreetCinemaTextBox.Text
                );
                AdminController.AddCinema(cinema);
                MessageBox.Show("Операция выполнена успешна!", "Успех.");
                NavigationService?.Navigate(new AdminPage());
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Неккоректный ввод полей!\n" + exception.Message, "Ошибка.");
            }
            catch (DbException exception)
            {
                MessageBox.Show("Неккоректное добавление в базу данных!\n" + exception.Message, "Ошибка.");
            }
            catch (ElementIsExistException exception)
            {
                MessageBox.Show("Неккоректное добавление в базу данных!\n" + exception.Message, "Ошибка.");

            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AdminPage());
        }
    }
}
