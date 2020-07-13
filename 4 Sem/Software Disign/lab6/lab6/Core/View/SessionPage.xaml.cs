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
    public partial class SessionPage : Page
    {
        public Page BackItem { get; }
        private Ticket[] tickets;
        private Ellipse[] placesArr;
        private CheckBox[] radioArr;
        private int selectedTicketsCount;
        private List<Ticket> selectedTickets;
        private Session currentSession;
        private double totalCost;

        public SessionPage(Page item, Session session)
        {
            selectedTickets = new List<Ticket>();
            currentSession = session;
            BackItem = item;

            tickets = MainController.GetTickets(session);
            MainController.SetTicketsStatus(tickets);   

            InitializeComponent();
            InitControlsArr();
            InitTickets();
            InitInfo();
        }

        private static string GetDurationLabel(int min)
        {
            int hours = min / 60;
            min %= 60;

            return $"Длительность фильма: {hours} : {min}";
        }

        private void InitInfo()
        {
            DescriotionTextBlock.Text = currentSession.Description;
            FilmNameLabel.Content = currentSession.FilmName;
            DurationLabel.Content = GetDurationLabel(currentSession.Duration);
        }

        private void InitControlsArr()
        {
            List<Ellipse> tmpList = new List<Ellipse>();
            tmpList.Add(Place1);
            tmpList.Add(Place2);
            tmpList.Add(Place3);
            tmpList.Add(Place4);
            tmpList.Add(Place5);
            tmpList.Add(Place6);
            tmpList.Add(Place7);
            tmpList.Add(Place8);
            tmpList.Add(Place9);
            tmpList.Add(Place10);
            tmpList.Add(Place11);
            tmpList.Add(Place12);
            tmpList.Add(Place13);
            tmpList.Add(Place14);
            tmpList.Add(Place15);
            tmpList.Add(Place16);
            placesArr = tmpList.ToArray();
            List<CheckBox> radioList = new List<CheckBox>();
            radioList.Add(CheckPlace1);
            radioList.Add(CheckPlace2);
            radioList.Add(CheckPlace3);
            radioList.Add(CheckPlace4);
            radioList.Add(CheckPlace5);
            radioList.Add(CheckPlace6);
            radioList.Add(CheckPlace7);
            radioList.Add(CheckPlace8);
            radioList.Add(CheckPlace9);
            radioList.Add(CheckPlace10);
            radioList.Add(CheckPlace11);
            radioList.Add(CheckPlace12);
            radioList.Add(CheckPlace13);
            radioList.Add(CheckPlace14);
            radioList.Add(CheckPlace15);
            radioList.Add(CheckPlace16);
            radioArr = radioList.ToArray();
        }

        private void InitTickets()
        {
            for (int i = 0; i < tickets.Length; i++)
            {
                int placeIndex = tickets[i].Place - 1;

                switch (tickets[i].StatusOfTicket)
                {
                    case Ticket.TicketStatus.OnlineAvailable:
                        placesArr[placeIndex].Fill = Brushes.MediumSpringGreen;
                        radioArr[placeIndex].Visibility = Visibility.Visible;
                        break;
                    case Ticket.TicketStatus.OfflineAvailable:
                        placesArr[placeIndex].Fill = Brushes.Yellow;
                        radioArr[placeIndex].Visibility = Visibility.Hidden;
                        break;
                    default:
                        placesArr[placeIndex].Fill = Brushes.Red;
                        radioArr[placeIndex].Visibility = Visibility.Hidden;
                        break;
                }
            }
        }

        private void GoBackButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(BackItem);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            var radio = ((CheckBox)sender);
            int placeNum = int.Parse(radio.Tag.ToString());
            var ticket = tickets.First(x => x.Place == placeNum);

            if (radio.IsChecked == true)
            {
                if (selectedTicketsCount == 5)
                {
                    radio.IsChecked = false;
                    MessageBox.Show("Нельзя купить больше пяти билетов.", "Ошибка");
                }
                else
                {
                    totalCost += ticket.Cost;
                    selectedTicketsCount++;
                    selectedTickets.Add(ticket);
                }
            }
            else
            {
                totalCost -= ticket.Cost;
                selectedTicketsCount--;
                selectedTickets.Remove(ticket);
            }

            TotalCostLabel.Content = "Цена: " + totalCost.ToString("0.##");
        }

        private void DoBuyButton_Click(object sender, RoutedEventArgs e)
        {
            if (selectedTicketsCount != 0)
            {
                NavigationService?.Navigate(new PaymentPage(this, selectedTickets.ToArray(),totalCost));
            }
            else
            {
                MessageBox.Show("Выберите хотя бы один билет.", "Ошибка");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new PersonalArea(new MainPage(MainController.CurrentUser)));
        }
    }
}
