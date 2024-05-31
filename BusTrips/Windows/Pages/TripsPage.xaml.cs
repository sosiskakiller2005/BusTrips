using BusTrips.Assets;
using BusTrips.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
        List<Trip> filteredTrips = new List<Trip>();
        public TripsPage(User selectedUser)
        {
            InitializeComponent();
            _selectedUser = selectedUser;
            filteredTrips = _context.Trip.ToList();
            List<City> allCities = _context.City.ToList();
            allCities.Insert(0, new City { 
                Name = "Все города" 
            });

            departureCityCmb.ItemsSource = allCities;
            departureCityCmb.SelectedItem = 0;
            departureCityCmb.DisplayMemberPath = "Name";
            destinationCityCmb.ItemsSource = allCities;
            destinationCityCmb.SelectedItem = 0;
            destinationCityCmb.DisplayMemberPath = "Name";
            tripsLV.ItemsSource = _context.Trip.ToList();
            sortCmb.ItemsSource = sortByList;
            sortCmb.SelectedIndex = 0;
        }

        private void buyTicketButton_Click(object sender, RoutedEventArgs e)
        {
            _selectedTrip = tripsLV.SelectedItem as Trip;
            if (!(_selectedTrip == null))
            {
                if (_selectedTrip.EmptySeats > 0)
                {
                    _selectedTrip = tripsLV.SelectedItem as Trip;
                    BuyTicketWindow buyTicketWindow = new BuyTicketWindow(_selectedTrip, _selectedUser);
                    buyTicketWindow.ShowDialog();
                }
                else
                {
                    MessageBoxHelper.Error("Все места на данный рейс раскуплены");
                }
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
                tripsLV.ItemsSource = filteredTrips.OrderBy(t => t.Route.DepartureCity.City.Name).ToList();
            }
            else if (sortCmb.SelectedIndex == 2)
            {
                tripsLV.ItemsSource = filteredTrips.OrderBy(t => t.Route.DepartureCity.City.Name).ToList();

            }
            else if (sortCmb.SelectedIndex == 3)
            {
                tripsLV.ItemsSource = filteredTrips.OrderBy(t => t.DateTimeOfArrival).ToList();
            }
            else if (sortCmb.SelectedIndex == 4)
            {
                tripsLV.ItemsSource = filteredTrips.OrderBy(t => t.DateTimeOfDeparture).ToList();

            }
            else
            {
                tripsLV.ItemsSource = filteredTrips.ToList();
            }
        }

        private void departureCityCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTrips();
        }

        private void destinationCityCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateTrips();
        }
        private void UpdateTrips()
        {
            if (departureCityCmb.SelectedIndex != 0)
            {
                if (destinationCityCmb.SelectedIndex !=0)
                {
                    filteredTrips = _context.Trip.ToList();
                    filteredTrips = filteredTrips.Where(t => t.Route.DepartureCity.City == departureCityCmb.SelectedValue).ToList();
                    filteredTrips = filteredTrips.Where(t => t.Route.DestinationCity.City == destinationCityCmb.SelectedValue).ToList();
                }
                else
                {
                    filteredTrips = _context.Trip.ToList();
                    filteredTrips = filteredTrips.Where(t => t.Route.DepartureCity.City == departureCityCmb.SelectedValue).ToList();
                }
            }
            else
            {
                if (destinationCityCmb.SelectedIndex != 0)
                {
                    filteredTrips = _context.Trip.ToList();
                    filteredTrips = filteredTrips.Where(t => t.Route.DestinationCity.City == destinationCityCmb.SelectedValue).ToList();
                }
                else
                {
                    filteredTrips = _context.Trip.ToList();
                }
            }
            tripsLV.ItemsSource = filteredTrips;
        }
    }
}
