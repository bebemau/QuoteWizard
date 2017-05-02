using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using DataTier;
using QuoteWizard.Filters;

namespace QuoteWizard.Controllers
{
    public class InsurersController : ApiController
    {
        private readonly IQuotesProvider _dataProvider;

        public InsurersController(IQuotesProvider quotesProvider)
        {
            _dataProvider = quotesProvider;
        }

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
