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
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        private BusTripsDbEntities _context = App.GetContext();
        Ticket _selectedTicket;
        User _selectedUser;
        public ProfilePage()
        {
            InitializeComponent();
            userGrid.DataContext = App.GetContext().User;
        }
        public ProfilePage(User selectedUser)
        {
            InitializeComponent();
            _selectedUser = selectedUser;
            userGrid.DataContext = selectedUser;
            ticketsLv.ItemsSource = selectedUser.Ticket.ToList();
            fullnameTbl.Text = selectedUser.Fullname;
        }

        private void deleteTicketBtn_Click(object sender, RoutedEventArgs e)
        {
            _selectedTicket = ticketsLv.SelectedItem as Ticket;
            if (!(_selectedTicket == null))
            {
                if (MessageBoxHelper.Question("Вернуть выбранный билет?") == true)
                {
                    _context.Ticket.Remove(_selectedTicket);
                    _context.SaveChanges();
                }
                ticketsLv.ItemsSource = _selectedUser.Ticket.ToList();
            }
            else
            {
                MessageBoxHelper.Error("Выберите билет");
            }
        }
    }
}
