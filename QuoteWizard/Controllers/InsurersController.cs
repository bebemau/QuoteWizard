using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataTier.Models;

namespace QuoteWizard.Controllers
{
    public class InsurersController : ApiController
    {
        private DataTier.QuotesProvider _dataProvider = new DataTier.QuotesProvider();

        [HttpGet]
        public List<string> Get()
        {
            var data = _dataProvider.GetQuoteSubset();
            var result = (from item in data
                          where item.FormerInsurer != string.Empty
                          orderby item.FormerInsurer
                      select item.FormerInsurer).Distinct(StringComparer.CurrentCultureIgnoreCase).ToList();
            result.Insert(0, string.Empty);
            return result;
        }
       
    }
}
