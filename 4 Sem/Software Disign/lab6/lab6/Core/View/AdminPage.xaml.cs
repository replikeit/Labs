using System;
using System.Collections.Generic;
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
    public partial class AdminPage : Page
    {
        private void AddSessionButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddSessionPage());
        }

        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LogInPage());
        }

        public AdminPage()
        {
            InitializeComponent();
        }

        private void AddCinemaButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new AddCinemaPage());
        }
    }
}
