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

namespace BusTrips.Windows
{
    /// <summary>
    /// Логика взаимодействия для UserWindow.xaml
    /// </summary>
    public partial class UserWindow : Window
    {
        User _selectedUser;

        public UserWindow(User selectedUser)
        {
            _selectedUser = selectedUser;
            InitializeComponent();
            DataContext = selectedUser;
            TripsPage tripsPage = new TripsPage(selectedUser as User);
            mainFrame.Navigate(tripsPage);
        }
        //public UserWindow()
        //{
        //    InitializeComponent();
        //    TripsPage tripsPage = new TripsPage();
        //    mainFrame.Navigate(tripsPage);
        //}

        private void TripsItem_Click(object sender, RoutedEventArgs e)
        {
            TripsPage tripsPage = new TripsPage(_selectedUser as User);
            mainFrame.Navigate(tripsPage);
        }

        private void ProfileItem_Click(object sender, RoutedEventArgs e)
        {
            ProfilePage profilePage = new ProfilePage(_selectedUser as User);
            mainFrame.Navigate(profilePage);
        }
    }
}
