using BusTrips.Assets;
using BusTrips.Models;
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
using System.Windows.Shapes;

namespace BusTrips.Windows.Views
{
    /// <summary>
    /// Логика взаимодействия для AuthorisationWindow.xaml
    /// </summary>
    public partial class AuthorisationWindow : Window
    {
        private BusTripsDbEntities _context = App.GetContext();
        public AuthorisationWindow()
        {
            InitializeComponent();
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            LoginWindow loginWindow = new LoginWindow();
            loginWindow.Show();
            Close();
        }

        private void registerBtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                foreach (User user in _context.User.ToList())
                {
                    if (loginTb.Text == user.Login)
                    {
                        MessageBoxHelper.Error("Пользователь с данным логином уже существует.");
                        break;
                    }
                    else
                    {
                        if (lastnameTb.Text == "" || nameTb.Text == "" || surnameTb.Text == "" || phoneTb.Text == "" || emailTb.Text == "" || loginTb.Text == "" || passwordTb.Password == "")
                        {
                            MessageBoxHelper.Error("Не все поля для ввода были заполнены.");
                            break;
                        }
                        else
                        {
                            User newUser = new User()
                            {
                                LastName = lastnameTb.Text,
                                Name = nameTb.Text,
                                Surname = surnameTb.Text,
                                PhoneNumber = phoneTb.Text,
                                Email = emailTb.Text,
                                Login = loginTb.Text,
                                Password = passwordTb.Password
                            };
                            _context.User.Add(newUser);
                            _context.SaveChanges();
                            LoginWindow loginWindow = new LoginWindow();
                            MessageBoxHelper.Information("Регистрация нового пользователя прошла успешно.");
                            loginWindow.Show();
                            Close();
                            break;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                MessageBoxHelper.Error(exception.InnerException);
            }
        }
    }
}
