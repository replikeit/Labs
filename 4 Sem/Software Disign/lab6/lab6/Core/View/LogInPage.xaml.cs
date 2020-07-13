using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для LogInPage.xaml
    /// </summary>
    public partial class LogInPage : Page
    {
        public LogInPage()
        {
            InitializeComponent();
            //CinemaContext.context.Users.Add(new User("admin", -1, "1"));
            //CinemaContext.context.Users.Add(new User("user", -1, "1"));
            //CinemaContext.context.SaveChanges();
            //CinemaContext.context.Users.Find(1).TypeOfUser = User.UserType.Worker;
            //CinemaContext.context.SaveChanges();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new RegisterPage());
        }


        private void LogInButton_Click(object sender, RoutedEventArgs e)
        {
            Database.SetInitializer<CinemaContext>(new DropCreateDatabaseIfModelChanges<CinemaContext>());

            var user = MainController.AuthenticationUser(LoginTextBox.Text, PasswordTextBox.Password);
            if (user != null)
                NavigationService?.Navigate((user.TypeOfUser == User.UserType.Client)? (object)new MainPage(user) : new AdminPage());
            else
            {
                LoginTextBox.BorderBrush = Brushes.Red;
                PasswordTextBox.BorderBrush = Brushes.Red;
                MessageBox.Show("Неверный логин или пароль!", "Ошибка входа");
            }
        }
    }
}
