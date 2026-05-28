using Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PracticingUI.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        
        private readonly AppDbContext _db;
        public RegistrationViewModel Registration { get; }
        public ObservableCollection<FlightRow> Flights { get; } = [];
        public MainWindowViewModel(AppDbContext db, 
            RegistrationViewModel registration)
        {
            _db = db;
            Registration = registration;
            LoadFlights();
        }

        private void LoadFlights()
        {
            var flights = _db.Flights
                .Include(f => f.DepartureAiport)
                .Include(f => f.ArrivalAirport)
                .ToList();

            foreach(var f in flights)
            {
                Flights.Add(new FlightRow(
                    f.FlightNumber,
                    f.DepartureAiport.City,
                    f.ArrivalAirport.City,
                    f.Departuretime,
                    f.ArrivalTime
                    ));
            }
        }
    }
    public record FlightRow(string FlightNumber, string From, string To,
        DateTime DepartureTime, DateTime ArrivalTime)
    {
        public string Status => "On schedule";
    }
}
