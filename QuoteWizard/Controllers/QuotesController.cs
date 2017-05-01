using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataTier.Models;

namespace QuoteWizard.Controllers
{
    [RoutePrefix("api/Quotes")]
    public class QuotesController : ApiController
    {
        private DataTier.QuotesProvider _dataProvider = new DataTier.QuotesProvider();

        [HttpGet]
        [Route("GetQuotesSubset")]
        public List<QuoteSubsetModel> GetQuotesSubset(string state="", string vehicleMake="", string formerInsurer="")
        {
            var result = _dataProvider.GetQuoteSubset(state, vehicleMake, formerInsurer);
            return result;
        }

        [HttpGet]
        [Route("GetQuoteDetail/{id}")]
        public QuoteDetailModel GetQuoteDetail(int id)
        {
            var result = _dataProvider.GetQuoteDetail(id);
            return result;
        }
    }
}
