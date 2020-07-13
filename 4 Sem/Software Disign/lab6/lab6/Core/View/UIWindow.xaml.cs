using System;
using System.Collections.Generic;
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

namespace lab6.Core.View
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class UIWindow : Window
    {
        public UIWindow()
        {
            CinemaContext.InitDbContext();
            InitializeComponent();
        }

        private void UIWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            MainFrame.NavigationService.Navigate(new LogInPage());
        }
    }
}
