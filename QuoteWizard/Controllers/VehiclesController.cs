using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataTier.Models;
using DataTier;
using QuoteWizard.Filters;

namespace QuoteWizard.Controllers
{
    public class VehiclesController : ApiController
    {
        private readonly IQuotesProvider _dataProvider;

        public VehiclesController(IQuotesProvider quotesProvider)
        {
            _dataProvider = quotesProvider;
        }

        [HttpGet]
        public List<string> Get()
        {
            var data = _dataProvider.GetQuoteSubset();

            var result = (from quotes in data
                          where quotes.Vehicles.Count > 0
                          from v in quotes.Vehicles
                          orderby v.Make
                          where v.Make != null
                          select v.Make).Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();
           
            result.Insert(0, string.Empty);
            return result;
        }
       
    }
}
