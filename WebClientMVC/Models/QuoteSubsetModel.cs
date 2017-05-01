using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClientMVC.Models
{
    public class QuoteSubsetModel
    {
        public int QuoteID { get; set; }
        public string CustomerFirstname { get; set; }
        public string CustomerLastname { get; set; }
        public string CustomerState { get; set; }
        public List<VehicleModel> Vehicles { get; set; }
        public string FormerInsurer { get; set; }
    }
}