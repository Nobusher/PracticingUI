using Database;
using Microsoft.EntityFrameworkCore;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive;
using System.Text;
using System.Threading.Tasks;

namespace PracticingUI.ViewModels
{
    public class RegistrationViewModel : ViewModelBase
    {
        private readonly AppDbContext _db;

        public ObservableCollection<Flight> Flights { get; } = [];

        private Flight? _selectedFlight;

        public Flight? SelectedFlight 
        {
            get { return _selectedFlight; }

            set =>this.RaiseAndSetIfChanged(ref  _selectedFlight, value);
        }
        private string _fullName = "";

        public string FullName 
        {
            get => _fullName;
            set => this.RaiseAndSetIfChanged(ref _fullName, value);
        }

        private string _seat = "";
        public string Seat 
        {
            get => _seat;
            set => this.RaiseAndSetIfChanged(ref _seat, value);
        }
        private decimal _price;
        public decimal Price
        {
            get => _price;
            set => this.RaiseAndSetIfChanged(ref _price, value);
        }
        private string _passportNumber = "";
        public string PassportNumber
        {
            get => _passportNumber;
            set =>this.RaiseAndSetIfChanged(ref _passportNumber, value);
        }

        public ReactiveCommand<Unit, Unit> RegisterCommand { get; }

        public RegistrationViewModel(AppDbContext db)
        {
            _db = db;

            var flights = _db.Flights
                .Include(f => f.DepartureAiport)
                .Include(f => f.ArrivalAirport)
                .ToList();

            RegisterCommand = ReactiveCommand.Create(Register);
        }
        private void Register()
        {
            if (SelectedFlight is null) return;

            var passanger = new Passenger
            {
                FullName = FullName,
                PassportNumber = PassportNumber
            };

            var ticket = new Ticket
            {
                Flight = SelectedFlight,
                Passenger = passanger,
                Seat = Seat,
                Price = Price,
            };
            _db.Tickets.Add(ticket);
            _db.SaveChanges();

            FullName = "";
            PassportNumber = "";
            Seat = "";
            Price = 0;
            SelectedFlight = null;
        }

    }
}
