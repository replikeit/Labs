using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Globalization;
using System.Linq;
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
using lab6.Core.Controllers;
using lab6.Core.Models;

namespace lab6.Core.View
{
    /// <summary>
    /// Логика взаимодействия для AddSessionPage.xaml
    /// </summary>
    public partial class AddSessionPage : Page
    {
        public AddSessionPage()
        {
            InitializeComponent();
        }

        private void AddSessionButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var session = new Session
                (
                    FilmNameTextBox.Text,
                    DateTime.ParseExact(FilmBeginDateTextBox.Text, "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                    int.Parse(LoungeNumberTextBox.Text),
                    MainController.GetCinemaByName(CinemaNameTextBox.Text).ID,
                    DescriptionTextBox.Text,
                    int.Parse(DurationTextBox.Text),
                    double.Parse(CostTextBox.Text)
                );
                AdminController.AddNewSession(session);
                MessageBox.Show("Операция выполнена успешна!", "Успех.");
                NavigationService?.Navigate(new AdminPage());
            }
            catch (FormatException exception)
            {
                MessageBox.Show("Неккоректный ввод поля!\n" + exception.Message, "Ошибка.");
            }
            catch (DbException exception)
            {
                MessageBox.Show("Неккоректное добавление в базу данных!\n" + exception.Message, "Ошибка.");
            }
            catch (NullReferenceException exception)
            {
                MessageBox.Show("Введенный кинотеатр не найден в базе данных!", "Ошибка.");
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AdminPage());
        }
    }
}
