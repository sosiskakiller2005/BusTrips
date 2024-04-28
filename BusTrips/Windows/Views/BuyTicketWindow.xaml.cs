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

namespace BusTrips.Windows
{
    /// <summary>
    /// Логика взаимодействия для BuyTicketWindow.xaml
    /// </summary>
    public partial class BuyTicketWindow : Window
    {
        private BusTripsDbEntities _context = App.GetContext();
        User _selectedUser;
        Trip _selectedTrip;
        public BuyTicketWindow()
        {
            InitializeComponent();
        }
        public BuyTicketWindow(Trip selectedTrip, User selectedUser)
        {
            InitializeComponent();
            Random random = new Random();
            _selectedUser = selectedUser;
            _selectedTrip = selectedTrip;

            lastnameTb.Text = selectedUser.LastName;
            nameTb.Text = selectedUser.Name;
            surnameTb.Text = selectedUser.Surname;
            phoneNumberTb.Text = selectedUser.PhoneNumber;
            emailTb.Text = selectedUser.Email;
            deportationCityTbl.Text = selectedTrip.Route.DepartureCity.City.Name;
            destinationCityTbl.Text = selectedTrip.Route.DestinationCity.City.Name;
            dateTimeOfDeportation.Text = selectedTrip.DateTimeOfDeparture.ToString("dd.MM.yyy HH:mm") ;
            dateTimeOfArrive.Text = selectedTrip.DateTimeOfArrival.ToString("dd.MM.yyy HH:mm");
            costTbl.Text = string.Format("{0:C2}", selectedTrip.Cost);
        }

        private void buyTicketBtn_Click(object sender, RoutedEventArgs e)
        {
                _selectedTrip.EmptySeats--;
                Ticket newTicket = new Ticket()
                {
                    UserId = _selectedUser.Id,
                    TripId = _selectedTrip.Id
                };
                _context.Ticket.Add(newTicket);
                _context.SaveChanges();
                this.Close();
                MessageBoxHelper.Information("Билет куплен");
        }
    }
}
