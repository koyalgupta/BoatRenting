using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRentSolution.Data.Models
{
    public class BoatDetails : Entity
    {
        public string BoatName { get; set; }
        public double HourlyRate { get; set; }
        public string BoatNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Rowstatus { get; set; }
    }
}
