using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DataTier.Models;
using Newtonsoft.Json;
using CommonUtilities;

namespace DataTier
{
    public class QuotesProvider : IQuotesProvider
    {
        private ConfigurationHelper _configurationHelper = new ConfigurationHelper();

        public List<QuoteDetailModel> GetData()
        {
            var config = _configurationHelper.Get<string>("PathToJsonFile");
            var path = HttpContext.Current.Server.MapPath(@config);

            try
            {
                using (StreamReader file = File.OpenText(@path))
                {
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.NullValueHandling = NullValueHandling.Ignore;
                    var dataset = (List<QuoteDetailModel>)serializer.Deserialize(file, typeof(List<QuoteDetailModel>));
                    return dataset;
                }
            }
            catch(Exception ex)
            {
                ErrorLogger.LogError(ex, "QuotesProvider.GetData");
                throw;
            }
        }

        public List<QuoteSubsetModel> GetQuoteSubset(string state = "", string vehicleMake = "", string formerInsurer = "")
        {
            var result = new List<QuoteSubsetModel>();

            var quoteDetailList = GetData();

            if (quoteDetailList.Count > 0)
            {
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
            }

            return result;
        }

        public QuoteDetailModel GetQuoteDetail(int quoteID)
        {
            var result = new QuoteDetailModel();

            var allQuotes = GetData();
            
            if(allQuotes.Count > 0)
            {
                result =allQuotes.Where(a => a.ID == quoteID).FirstOrDefault();
            }

            return result;
        }


    }
}
