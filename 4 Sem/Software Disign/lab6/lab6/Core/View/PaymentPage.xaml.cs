using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
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
    public partial class PaymentPage : Page
    {
        public Page BackItem { get; }
        private Ticket[] tickets;

        public PaymentPage(Page item, Ticket[] arr, double totalCost)
        {
            BackItem = item;
            tickets = arr;
            InitializeComponent();
            TotalCostLabel.Content = $"К оплате: {totalCost.ToString("0.##")}";
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            MainController.SetTicketsStatus(Ticket.TicketStatus.OnlineAvailable, tickets);
            NavigationService?.Navigate(BackItem);
        }

        private void AcceptBuyTicketButton_Click(object sender, RoutedEventArgs e)
        {
            BankController.BuyTickets(tickets);
            NavigationService?.Navigate(new MainPage(MainController.CurrentUser));
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        { 
            NavigationService?.Navigate(new PersonalArea(this));
        }
    }
}
