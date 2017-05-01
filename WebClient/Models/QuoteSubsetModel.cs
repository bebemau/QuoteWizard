using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebClient.Models
{
    public class QuoteSubsetModel
    {
        public int QuoteID { get; set; }
        public string CustomerFirstname { get; set; }
        public string CustomerLastname { get; set; }
        public List<VehicleModel> Vehicles { get; set; }
        public string FormerInsurer { get; set; }
    }
}