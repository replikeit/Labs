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
    public partial class RegisterPage : Page
    {
        private bool phoneIsValid, mailIsValid, passIsValid;

        public RegisterPage()
        {
            InitializeComponent();
            if (!(DoRegisterButton.IsEnabled = CheckButtonEnabled()))
                DoRegisterButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4c4a4b"));
        }

        private void BackToLoginButton_Click(object sender, RoutedEventArgs e)
        {
            NavigationService?.Navigate(new LogInPage());
        }

        private bool CheckButtonEnabled() => (phoneIsValid && mailIsValid && passIsValid);


        private void DoRegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var curUser = new User
            (
                MailTextBox.Text,
                long.Parse(Phone.Text.Substring(1)),
                PasswordTextBox.Password
            );

            if (MainController.AddNewUser(curUser))
            {
                NavigationService.Navigate(new MainPage(curUser));
            }
            else
            {
                MessageBox.Show("Пользователь с такой почтой уже зарегистрирован.", "Ошибка регистрациию.");
            }
        }

        private void OnSelectionChanged(object sender, RoutedEventArgs e)
        {
            var textBox = sender as TextBox;

            bool isMatch;
            switch (textBox?.Tag.ToString())
            {
                case "Mail":
                    isMatch = Regex.IsMatch(textBox.Text,
                        @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z",
                        RegexOptions.IgnoreCase);
                    if (isMatch)
                    {
                        textBox.BorderBrush = Brushes.LimeGreen;
                        mailIsValid = true;
                    }
                    else
                    {
                        textBox.BorderBrush = Brushes.Red;
                        mailIsValid = false;
                    }
                    break;
                case "PhoneNumber":
                    isMatch = Regex.IsMatch(textBox.Text, @"\+([1-9]{12})");
                    if (isMatch)
                    {
                        textBox.BorderBrush = Brushes.LimeGreen;
                        phoneIsValid = true;
                    }
                    else
                    {
                        textBox.BorderBrush = Brushes.Red;
                        phoneIsValid = false;
                    }
                    break;
            }

            SetButtonEnable();
        }

        private void SetButtonEnable()
        {
            if (!(DoRegisterButton.IsEnabled = CheckButtonEnabled()))
                DoRegisterButton.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#4c4a4b"));
            else
                DoRegisterButton.Foreground = Brushes.WhiteSmoke;
        }

        private void PasswordBox_OnTextInput(object sender, EventArgs e)
        {
            var textBox = sender as PasswordBox;

            switch (textBox?.Tag.ToString())
            {
                case "Password":
                    if (textBox.Password.Length > 5)
                    {
                        textBox.BorderBrush = Brushes.LimeGreen;
                        if (textBox.Password != ConfirmPasswordTextBox.Password)
                        {
                            ConfirmPasswordTextBox.BorderBrush = Brushes.Red;
                            passIsValid = false;
                        }
                        else
                        {
                            ConfirmPasswordTextBox.BorderBrush = Brushes.LimeGreen;
                            passIsValid = true;
                        }
                    }
                    else
                    {
                        textBox.BorderBrush = Brushes.Red;
                        passIsValid = false;
                    }
                    break;
                case "ConfirmPassword":
                    if (textBox.Password != PasswordTextBox.Password)
                    {
                        ConfirmPasswordTextBox.BorderBrush = Brushes.Red;
                        passIsValid = false;
                    }
                    else
                    {
                        if (PasswordTextBox.Password.Length < 5)
                        {
                            PasswordTextBox.BorderBrush = Brushes.Red;
                            passIsValid = false;
                        }
                        else
                        {
                            ConfirmPasswordTextBox.BorderBrush = Brushes.LimeGreen;
                            passIsValid = true;
                        }
                    }
                    break;
            }

            SetButtonEnable();
        }
    }
}
