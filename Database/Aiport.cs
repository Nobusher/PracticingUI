using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Aiport
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string IataCode { get; set; } = null!;
        public string City { get; set; } = null!;
        public ICollection<Flight> DepartureFlight { get; set; } = [];
        public ICollection<Flight> ArrivalFlights { get; set; } = [];
    }
}
