using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities.APIHelpers
{
    public class HttpClientHelper : IHttpClientHelper 
    {
        private ConfigurationHelper configurationHelper = new ConfigurationHelper();

        public HttpClient GetClient()
        {
            var client = new HttpClient();
            var baseUri = configurationHelper.Get<string>("ApiBaseUri");
            //client.BaseAddress = new Uri("http://localhost:8888/api/");
            client.BaseAddress = new Uri(baseUri);
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.MaxResponseContentBufferSize = int.MaxValue;
            return client;
        }
        
    }
}
