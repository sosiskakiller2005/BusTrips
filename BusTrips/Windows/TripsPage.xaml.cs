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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BusTrips.Windows
{
    /// <summary>
    /// Логика взаимодействия для TripsPage.xaml
    /// </summary>
    public partial class TripsPage : Page
    {
        Trip _selectedTrip;
        User _selectedUser;
        List<string> sortByList = new List<string>()
            {
                "Все рейсы",
                "По городу отправления",
                "По городу прибытия",
                "По дате отправления",
                "По дате прибытия"
            };
        BusTripsDbEntities _context = App.GetContext();
        public TripsPage()
        {
            InitializeComponent();
            tripsLV.ItemsSource = App.GetContext().Trip.ToList();
        }
        public TripsPage(User selectedUser)
        {
            InitializeComponent();
            _selectedUser = selectedUser;
            tripsLV.ItemsSource = App.GetContext().Trip.ToList();
            sortCmb.ItemsSource = sortByList;
            sortCmb.SelectedIndex = 0;
        }

        private void buyTicketButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedTrip = tripsLV.SelectedItem as Trip;
            if (!(_selectedTrip == null))
            {
                _selectedTrip = tripsLV.SelectedItem as Trip;
                BuyTicketWindow buyTicketWindow = new BuyTicketWindow(_selectedTrip, _selectedUser);
                buyTicketWindow.ShowDialog();
            }
            else
            {
                MessageBoxHelper.Error("Выберите поездку");
            }
        }
        private void sortCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (sortCmb.SelectedIndex == 1)
            {
                tripsLV.ItemsSource = _context.Trip.OrderBy(t => t.Route.City.Name).ToList();
            }
            else if (sortCmb.SelectedIndex == 2)
            {
                tripsLV.ItemsSource = _context.Trip.OrderBy(t => t.Route.City1.Name).ToList();

            }
            else if (sortCmb.SelectedIndex == 3)
            {
                tripsLV.ItemsSource = _context.Trip.OrderBy(t => t.DateTimeOfArrival).ToList();
            }
            else if (sortCmb.SelectedIndex == 4)
            {
                tripsLV.ItemsSource = _context.Trip.OrderBy(t => t.DateTimeOfDeparture).ToList();

            }
            else
            {
                tripsLV.ItemsSource = _context.Trip.ToList();
            }
        }
    }
}
