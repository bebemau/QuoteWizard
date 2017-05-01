using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.Models
{
    public class VehicleModel
    {
        public int Year { get; set; }
        public string Make { get; set; }

        public string Model { get; set; }
        public int Days_Used { get; set; }
        public string Use { get; set; }
        public int Distance { get; set; }
        public int Annual_Distance { get; set; }
    }
}
