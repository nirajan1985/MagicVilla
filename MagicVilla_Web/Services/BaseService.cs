using MagicVilla_Web.Models;
using Newtonsoft.Json;

namespace MagicVilla_Web.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }
        public BaseService(IHttpClientFactory httpClient) 
        {
            this.responseModel = new();
            this.httpClient = httpClient;

        }

        public Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client= httpClient.CreateClient("MagicAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                if(apiRequest.Data!= null)
                {
                    message.Content=new StringContent(JsonConvert.SerializeObject(apiRequest.Data),
                        encoding.UTF8, "application/json");
                }
            }
        }
    }
}
