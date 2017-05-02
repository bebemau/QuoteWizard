using System.Collections.Generic;
using DataTier.Models;

namespace DataTier
{
    public interface IQuotesProvider
    {
        List<QuoteDetailModel> GetData();
        QuoteDetailModel GetQuoteDetail(int quoteID);
        List<QuoteSubsetModel> GetQuoteSubset(string state = "", string vehicleMake = "", string formerInsurer = "");
    }
}