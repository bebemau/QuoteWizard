using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebClient.APIHelpers;
using WebClient.Models;

namespace WebClient
{
    public partial class Default : System.Web.UI.Page
    {
        HttpClientHelper clientHelper = new HttpClientHelper();
        RESTHelper apiHelper = new RESTHelper();
        HttpClient client = new HttpClient();
        List<QuoteSubsetModel> quoteSubsetModel = new List<QuoteSubsetModel>();

        protected async void Page_Load(object sender, EventArgs e)
        {
            await GetData();
            lv.DataSource = quoteSubsetModel;
        }

        private async Task GetData()
        {
            client = clientHelper.GetClient();
            quoteSubsetModel = await RESTHelper.GetListOfObjects<QuoteSubsetModel>("api/quotes/getquotesSubset", client);
        }

        protected void ListView1_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {
            DataPager dp = (DataPager)lv.FindControl("DataPager1");
            dp.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            //getData(lv);

        }
    }
}