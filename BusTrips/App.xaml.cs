using BusTrips.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace BusTrips
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static BusTripsDbEntities _context;
        public static BusTripsDbEntities GetContext()
        {
            if (_context == null)
            {
                _context = new BusTripsDbEntities();
            }
            return _context;
        }
    }
}
