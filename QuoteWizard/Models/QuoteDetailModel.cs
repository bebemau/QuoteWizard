using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuoteWizard.Models
{
    public class QuoteDetailModel
    {
        public int ID { get; set; }
        public ConsumerModel Consumer { get; set; }
        public List<VehicleModel> Vehicle { get; set; }
        public CoverageModel Coverage { get; set; }
    }
}
