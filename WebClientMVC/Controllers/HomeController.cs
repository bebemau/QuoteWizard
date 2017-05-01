using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;
using WebClientMVC.Models;
using System.Net.Http.Formatting;

namespace WebClientMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(string state = "", string vehicleMake = "", string formerInsurer = "")
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
                uri += appended ? "&" : "?" + "vehicleMake=" + vehicleMake;
                appended = true;
            }
            if (formerInsurer != string.Empty)
            {
                uri += appended ? "&" : "?" + "formerInsurer=" + formerInsurer;
            }

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8888/api/");

                var responseTask = client.GetAsync(uri);
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<QuoteSubsetModel>>();
                    readTask.Wait();

                    data = readTask.Result.ToList();

                    PopulateState();
                    PopulateInsurer();
                }
                else 
                {
                    data = new List<QuoteSubsetModel>();

                    ModelState.AddModelError(string.Empty, "There was an error processing the request.");
                }
            }
            return View(data);
        }

        public ActionResult QuoteDetails()
        {
            ViewBag.Message = "Quote Details page.";

            return View();
        }

        private void PopulateState()
        {
            var data = new List<string>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8888/api/");

                var responseTask = client.GetAsync("states/getstates");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<string>>();
                    readTask.Wait();

                    data = readTask.Result.ToList();

                }
                else
                {
                    data = new List<string>();

                    ModelState.AddModelError(string.Empty, "There was an error processing the request.");
                }
            }

            ViewBag.State = data;
        }

        private void PopulateInsurer()
        {
            var data = new List<string>();

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:8888/api/");

                var responseTask = client.GetAsync("insurers");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<IList<string>>();
                    readTask.Wait();

                    data = readTask.Result.ToList();

                }
                else
                {
                    data = new List<string>();

                    ModelState.AddModelError(string.Empty, "There was an error processing the request.");
                }
            }

            ViewBag.FormerInsurer = data;
        }

    }
}