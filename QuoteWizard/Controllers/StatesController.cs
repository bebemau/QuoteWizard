using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataTier.Models;

namespace QuoteWizard.Controllers
{
    public class StatesController : ApiController
    {
        private DataTier.QuotesProvider _dataProvider = new DataTier.QuotesProvider();

        [HttpGet]
        public List<string> Get()
        {
            var data = _dataProvider.GetQuoteSubset();
            var result = (from item in data
                          where item.CustomerState != string.Empty
                          orderby item.CustomerState
                      select item.CustomerState).Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();
            result.Insert(0, string.Empty);
            return result;
        }
       
    }
}
