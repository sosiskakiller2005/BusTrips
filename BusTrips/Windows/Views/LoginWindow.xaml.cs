﻿using BusTrips.Windows;
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
using BusTrips.Windows.Views;
using BusTrips.Assets;

namespace BusTrips.Windows
{
    /// <summary>
    /// Логика взаимодействия для LoginWindow.xaml
    /// </summary>
    public partial class LoginWindow : Window
    {
        private BusTripsDbEntities _context = App.GetContext();
        User _selectedUser;
        public LoginWindow()
        {
            InitializeComponent();
        }
        
        private void enterBtn_Click(object sender, RoutedEventArgs e)
        {
                List<User> users = _context.User.ToList();
            
                if (loginTb.Text == "" && passwordTb.Password == "")
                {
                    MessageBoxHelper.Error("Введите логин и пароль");
                }
                else if (loginTb.Text == "")
                {
                    MessageBoxHelper.Error("Введите логин");
                }
                else if (passwordTb.Password == "")
                {
                    MessageBoxHelper.Error("Введите пароль");
                }
                else
                {
                    string login = loginTb.Text;
                    string password = passwordTb.Password;
                    foreach (User user in users)
                    {
                        if (user.Login == login & user.Password == password)
                        {
                            _selectedUser = user;
                            UserWindow userWindow = new UserWindow(_selectedUser as User);
                            userWindow.Show();
                            this.Close();
                            break;
                        }
                    }
                if (_selectedUser == null)
                {
                    MessageBoxHelper.Error("Пользователь с данным логином не найден");
                }
                }
        }

        private void Hyperlink_Click(object sender, RoutedEventArgs e)
        {
            AuthorisationWindow authorisationWindow = new AuthorisationWindow();
            authorisationWindow.Show();
            Close();
        }
    }
}
