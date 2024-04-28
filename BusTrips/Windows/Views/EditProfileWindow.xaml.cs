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
    /// Логика взаимодействия для EditProfileWindow.xaml
    /// </summary>
    public partial class EditProfileWindow : Window
    {
        private BusTripsDbEntities _context = App.GetContext();  
        private User _selectedUser;
        public EditProfileWindow(User selectedUser)
        {
            InitializeComponent();
            _selectedUser = selectedUser;
            lastnameTb.Text = _selectedUser.LastName;
            nameTb.Text = _selectedUser.Name;
            surnameTb.Text = _selectedUser.Surname;
            phoneTb.Text = _selectedUser.PhoneNumber;
            emailTb.Text = _selectedUser.Email;
            loginTb.Text = _selectedUser.Login;
            passwordTb.Text = _selectedUser.Password;
        }

        private void applyChangesButton_Click(object sender, RoutedEventArgs e)
        {
            if (lastnameTb.Text != "" & nameTb.Text != "" & surnameTb.Text != "" & phoneTb.Text != "" & emailTb.Text != "" & loginTb.Text != "" & passwordTb.Text != "")
            {
                _selectedUser.LastName = lastnameTb.Text;
                _selectedUser.Name = nameTb.Text;
                _selectedUser.Surname = surnameTb.Text;
                _selectedUser.PhoneNumber = phoneTb.Text;
                _selectedUser.Email = emailTb.Text;
                _selectedUser.Login = loginTb.Text;
                _selectedUser.Password = passwordTb.Text;
                _context.SaveChanges();
                MessageBoxHelper.Information("Данные профиля изменены.");
                Close();
            }
            else
            {
                MessageBoxHelper.Error("Не все поля для ввода заполнены.");
            }
        }
    }
}
