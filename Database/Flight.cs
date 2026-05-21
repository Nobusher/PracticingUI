using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; } = null!;
        public DateTime Departuretime { get; set; }
        public DateTime ArrivalTime { get; set; }

        public int DepartureAiportId { get; set; }
        public Aiport DepartureAiport { get; set; } = null!;
        public int ArrivalAirportId { get; set; }
        public Aiport ArrivalAirport { get; set; } = null!;

        public ICollection<Ticket> Tickets { get; set; } = [];
    }
}
