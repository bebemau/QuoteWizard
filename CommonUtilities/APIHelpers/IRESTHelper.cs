using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CommonUtilities.APIHelpers
{
    public interface IRESTHelper
    {
        Task<List<T>> GetListOfObjects<T>(string uri, HttpClient client);
        Task<T> GetSingleObject<T>(string uri, HttpClient client);
    }
} 