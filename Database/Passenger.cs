using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public class Passenger
    {
        public int Id {  get; set; }
        public string FullName { get; set; } = null!;
        public string PassportNumber { get; set; } = null!;
        public ICollection<Ticket> Tickets { get; set; } = [];
    }
}
