using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTier.Models
{
    public class CoverageModel
    {
        public int Months_Insured { get; set; }
        public string Has_Coverage { get; set; }
        public string Type { get; set; }
        public int BodilyInjury_Person { get; set; }
        public int BodilyInjury_Accident { get; set; }
        public int Deductible { get; set; }
        public int PropertyDamage { get; set; }
        public DateTime Expiration_Date { get; set; }
        public int Expiration_Days_Remaining { get; set; }
        public DateTime DtgExpirationDate { get; set; }
        public string Former_Insurer { get; set; }
    }
}
