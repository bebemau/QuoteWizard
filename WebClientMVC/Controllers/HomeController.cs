using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebClientMVC.Models;
using System.Net.Http.Formatting;
using PagedList;
using CommonUtilities.APIHelpers;
using System.Threading.Tasks;
using CommonUtilities;

namespace WebClientMVC.Controllers
{
    [ExceptionHandler]
    public class HomeController : Controller
    {
        private HttpClient client = new HttpClient();
        private readonly IHttpClientHelper _clientHelper;
        private readonly IRESTHelper _restHelper;
        private readonly IConfigurationHelper _configurationHelper;

        public HomeController(IHttpClientHelper httpClientHelper, IRESTHelper restHelper, IConfigurationHelper configurationHelper)
        {
            _clientHelper = httpClientHelper;
            _restHelper = restHelper;
            _configurationHelper = configurationHelper;
        }

        public async Task<ActionResult> Index(int? page, string state = "", string vehicleMake = "", string formerInsurer = "")
        {
            List<QuoteSubsetModel> data = null;
            var uri = "quotes/getquotesSubset";
            bool appended = false;

            if (state != string.Empty)
            {
                uri += "?state=" + state;
                appended = true;
            }
            if (vehicleMake != string.Empty)
            {
                if(appended)
                    uri += "&";
                else
                    uri += "?";

                uri += "vehicleMake=" + vehicleMake;
                appended = true;
            }
            if (formerInsurer != string.Empty)
            {
                if (appended)
                    uri += "&";
                else
                    uri += "?";

                uri += "formerInsurer=" + formerInsurer;
            }

            client = _clientHelper.GetClient();
            data = await _restHelper.GetListOfObjects<QuoteSubsetModel>(uri, client);
            if (data.Count < 1)
            {
                ViewBag.EmptyDataset = true;
            }

            await PopulateState();
            await PopulateInsurer();
            await PopulateVehicleMake();

            var pageSize = _configurationHelper.Get<int>("PageSize");
            int pageNumber = (page ?? 1);

            return View(data.ToPagedList(pageNumber, pageSize));
            
        }

        public async Task<ActionResult> QuoteDetail(int id)
        {
            var data = new QuoteDetailModel();

            if (id != 0)
            {
                var uri = "quotes/getQuotedetail/" + id.ToString();

                client = _clientHelper.GetClient();
                data = await _restHelper.GetSingleObject<QuoteDetailModel>(uri, client);
            }

            return View(data);
        }

        private async Task PopulateState()
        {
            var data = new List<string>();

            client = _clientHelper.GetClient();
            data = await _restHelper.GetSingleObject<List<string>>("states", client);

            ViewBag.State = data;
        }

        private async Task PopulateInsurer()
        {
            var data = new List<string>();

            client = _clientHelper.GetClient();
            data = await _restHelper.GetSingleObject<List<string>>("insurers", client);

            ViewBag.FormerInsurer = data;
        }

        private async Task PopulateVehicleMake()
        {
            var data = new List<string>();

            client = _clientHelper.GetClient();
            data = await _restHelper.GetSingleObject<List<string>>("vehicles", client);

            ViewBag.VehicleMake = data;
        }

    }
}