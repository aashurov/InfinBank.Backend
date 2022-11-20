using System.Net.Http;

namespace InfinBank.Persistence.Services
{
    public class PublicHttp
    {
        public HttpClient Client { get; private set; }

        public PublicHttp(HttpClient httpClient)
        {
            Client = httpClient;
        }
    }
}