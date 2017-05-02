using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CommonUtilities.APIHelpers
{
    public class RESTHelper : IRESTHelper 
    {
        public async Task<List<T>> GetListOfObjects<T>(string uri, HttpClient client)
        {
            var returnobj = new List<T>();
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                returnobj = JsonConvert.DeserializeObject<List<T>>(content);
            }
            else
                throw new HttpRequestException("Did not receive valid GetListOfObjects response.");

            return returnobj;
        }

        public async Task<T> GetSingleObject<T>(string uri, HttpClient client)
        {
            var response = await client.GetAsync(uri);
            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<T>(content);
                return (T)Convert.ChangeType(result, typeof(T));
            }
            else
                throw new HttpRequestException("Did not receive valid GetSingleObject response.");

        }

    }
}
