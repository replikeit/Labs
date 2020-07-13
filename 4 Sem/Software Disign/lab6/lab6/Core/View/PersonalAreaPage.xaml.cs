using lab6.Core.Controllers;
using lab6.Core.Models;
using System;
using System.Data;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace lab6.Core.View
{
    /// <summary>
    /// Логика взаимодействия для LogInPage.xaml
    /// </summary>
    public partial class PersonalArea : Page
    {
        private Page backPage;
        private Session[] availableSessions;
        private Ticket[] tickets;
        private int selectedIndex;
        private bool isFirstSelect;
        public PersonalArea(Page page)
        {
            backPage = page;
            tickets = MainController.GetAllTickets().Where(x=>x.OwnerID == MainController.CurrentUser.ID).ToArray();
            InitializeComponent();
            InitControls();
            SetButtonEnable(ReturnTicketButton);
            isFirstSelect = true;
        }

        private void InitControls()
        {
            foreach (var ticket in tickets)
                TicketsListBox.Items.Add(ticket.FilmName);
            ProfileInfoLabel.Content = GetLabelProfile(MainController.CurrentUser);
        }

        private static string GetLabelProfile(User user)
        {
            string status = null;
            switch (user.LevelOfClient)
            {
                case User.ClientLevel.Common:
                    status = "Обычный клиент";
                    break;
                case User.ClientLevel.Regular:
                    status = "Постоянный клиент";
                    break;
                case User.ClientLevel.VIP:
                    status = "VIP клиент";
                    break;
            }
            return  $"Электронная почта: {user.Login}\n\n" +
                    $"Телефон: {user.PhoneNumber}\n\n" +
                    $"Потраченная сумма: {user.AmountSpent}\n\n" +
                    $"Статус профиля: {status}\n\n";
        }

        private static string GetLabelDescription(Ticket ticket)
        {
            var cinema = MainController.GetCinemaByID(ticket.CinemaID);
            return $"Название фильма: {ticket.FilmName}\n\n" +
                   $"Время и дата начала: {ticket.BeginTime.Date.ToString("f")}\n\n" +
                   $"Кинотеатр: \"{cinema.Name}\"\n\n " +
                   $"Адрес кинотеатра: {cinema.Street}\n\n" +
                   $"Номер зала: {ticket.LoungeNum}\n\n" +
                   $"Ряд: {ticket.Row}\n\n" +
                   $"Место: {ticket.Place}\n\n" +
                   $"Цена билета: {ticket.Cost.ToString("#0.##")}";
        }

        private static void SetButtonEnable(Button but)
        {
            if (but.IsEnabled)
            {
                but.IsEnabled = !but.IsEnabled;
                but.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4c4a4b"));
            }
            else
            {
                but.IsEnabled = !but.IsEnabled;
                but.Foreground = Brushes.WhiteSmoke;
            }
        }

        private void TicketsListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var listBox = (ListBox)sender;
            if (listBox.Items.Count == 0) return;

            TicketDescriptionLabel.Content = GetLabelDescription(tickets[listBox.SelectedIndex]);
            selectedIndex = listBox.SelectedIndex;
                
            if (isFirstSelect) SetButtonEnable(ReturnTicketButton);

            isFirstSelect = false;
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(backPage);
        }

        private void ReturnTicketButton_Click(object sender, RoutedEventArgs e)
        {
            if ((tickets[selectedIndex].BeginTime - DateTime.Now).TotalMinutes >= 30)
            {
                TicketsListBox.Items.RemoveAt(selectedIndex);
                BankController.ReturnTickets(tickets[selectedIndex]);

                SetButtonEnable(ReturnTicketButton);
                isFirstSelect = true;
            }
            else
                MessageBox.Show("Время сдачи билета прошло.\n Возврат не возможен", "Ошибка");
        }

        private void LogOutButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LogInPage());
        }
    }
}
