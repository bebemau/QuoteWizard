using System.Net.Http;

namespace CommonUtilities.APIHelpers
{
    public interface IHttpClientHelper
    {
        HttpClient GetClient();
    }
} 