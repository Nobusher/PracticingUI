using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Seat { get; set; } = null!;
        public decimal Price { get; set; }

        public int FlightId { get; set; }
        public Flight Flight { get; set; } = null!;
        public int PassengerId { get; set; }
        public Passenger Passenger { get; set; } = null!;
    }
}
