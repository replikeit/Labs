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
    public partial class MainPage : Page
    {
        public User CurrentUser { get; set; }

        private Session[] availableSessions;

        public MainPage(User user)
        {
            CurrentUser = user;
            availableSessions = MainController.GetAvailableSessions();
            InitializeComponent();
            InitTable(availableSessions);
            InitControls();
        }

        private void InitControls()
        {
            var cinemas = MainController.GetAllCinemas();
            BeginDiapasonCalendar.SelectedDate = DateTime.Now;  
            BeginCalendarButton.Content = DateTime.Now.ToString("dd / MM");
            EndDiapasonCalendar.SelectedDate = DateTime.Now.AddDays(7);
            EndCalendarButton.Content = DateTime.Now.AddDays(7).ToString("dd / MM");
            foreach (var cinema in cinemas)
            {
                CinemasComboBox.Items.Add(cinema.Name);
            }
        }

        private void InitTable(Session[] arr)
        {
            SessionsDataGrid.Items.Clear();
            foreach (var session in arr)
            {
                var item = new
                {
                    id = session.ID,
                    FilmName = session.FilmName,
                    Description = session.Description,
                    BeginTime = session.BeginTime.ToUniversalTime().ToString("dd/MM   HH:mm"),
                    CinemaName = MainController.GetCinemaByID(session.CinemaID).Name,
                };
                SessionsDataGrid.Items.Add(item);
            }
        }

        private void DoSearchButton_Click(object sender, RoutedEventArgs e)
        {
            Session[] tmpArr = availableSessions;
            if (!String.IsNullOrEmpty(SearchTextBox.Text))
                tmpArr = tmpArr.Where(x => x.FilmName.ToLower().Contains(SearchTextBox.Text.ToLower())).ToArray();

            tmpArr = tmpArr.Where(x => x.BeginTime.Date >= BeginDiapasonCalendar.SelectedDate).ToArray();
            tmpArr = tmpArr.Where(x => x.BeginTime.Date <= EndDiapasonCalendar.SelectedDate).ToArray();
           
            if (CinemasComboBox.SelectionBoxItem.ToString() != "Любой")
                tmpArr = tmpArr.Where(x => x.CinemaID == MainController.GetCinemaByName(CinemasComboBox.SelectionBoxItem.ToString()).ID).ToArray();

            InitTable(tmpArr);
        }

        private void GetTicketsButton_OnClick(object sender, RoutedEventArgs e)
        {
            for (var vis = sender as Visual; vis != null; vis = VisualTreeHelper.GetParent(vis) as Visual)
                if (vis is DataGridRow)
                {
                    var row = (DataGridRow)vis;
                    dynamic d = row.DataContext;
                    NavigationService?.Navigate(new SessionPage(this, availableSessions.First(x => x.ID == d.id)));
                    break;
                }
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

        private void SelectedOnCalendar(object sender, EventArgs e)
        {
            var calendar = (System.Windows.Controls.Calendar)sender;
            switch (calendar.Tag.ToString())
            {
                case "Begin":
                    BeginCalendarButton.Content = calendar.SelectedDate?.ToString("dd / MM");
                    SetButtonEnable(BeginCalendarButton);
                    break;
                case "End":
                    EndCalendarButton.Content = calendar.SelectedDate?.ToString("dd / MM");
                    SetButtonEnable(EndCalendarButton);
                    break;
            }
            calendar.Visibility = Visibility.Hidden;
        }

        private void CalendarButton_Click(object sender, RoutedEventArgs e)
        {
            var but = sender as Button;
            switch (but.Tag.ToString())
            {
                case "Begin":
                    BeginDiapasonCalendar.Visibility = Visibility.Visible;
                    break;
                case "End":
                    EndDiapasonCalendar.Visibility = Visibility.Visible;
                    break;
            }
            SetButtonEnable(but);
        }

        private void PersonalAreaButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new PersonalArea(this));
        }
    }
}
