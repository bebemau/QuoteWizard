using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Configuration;
using DataTier.Models;
using Newtonsoft.Json;

namespace DataTier
{
    public class QuotesProvider
    {

        public List<QuoteDetailModel> GetData()
        {
            var config = ConfigurationSettings.AppSettings["PathToJsonFile"];
            var path = HttpContext.Current.Server.MapPath(@config);

            //var serializer = new JsonSerializer();
            //var obj = serializer.Deserialize<QuoteModel>(File.ReadAllText(@".\path\to\json\config\file.json");

            using (StreamReader file = File.OpenText(@path))
            {
                JsonSerializer serializer = new JsonSerializer();
                serializer.NullValueHandling = NullValueHandling.Ignore;
                var dataset = (List<QuoteDetailModel>)serializer.Deserialize(file, typeof(List<QuoteDetailModel>));
                return dataset;
            }


            //var dataset = JArray.Parse(File.ReadAllText(path));
            //return dataset.ToObject<List<QuoteModel>>();
        }

        public List<QuoteSubsetModel> GetQuoteSubset(string state="", string vehicleMake="", string formerInsurer="")
        {
            var result = new List<QuoteSubsetModel>();

            var quoteDetailList = GetData();

            result = quoteDetailList.Select(m => new QuoteSubsetModel
            {
                CustomerFirstname = m.Consumer.First_Name,
                CustomerLastname = m.Consumer.Last_Name,
                FormerInsurer = m.Coverage.Former_Insurer,
                CustomerState = m.Consumer.State,
                QuoteID = m.ID,
                Vehicles = m.Vehicle.Where(k => k.Make.ToLower() == (vehicleMake != string.Empty ? vehicleMake.ToLower() : k.Make.ToLower())).ToList()
            }).Where(k => k.FormerInsurer.ToLower() == (formerInsurer != string.Empty ? formerInsurer.ToLower() : k.FormerInsurer.ToLower())
            && k.CustomerState.ToLower() == (state != string.Empty ? state.ToLower() : k.CustomerState.ToLower())
            && k.Vehicles.Any(h => h.Make.ToLower() == (vehicleMake != string.Empty ? vehicleMake.ToLower() : h.Make.ToLower()))
            ).ToList();

            return result;
        }

        public QuoteDetailModel GetQuoteDetail(int quoteID)
        {
            var result = new QuoteDetailModel();

            result = GetData().Where(a => a.ID == quoteID).FirstOrDefault();

            return result;
        }


    }
}
