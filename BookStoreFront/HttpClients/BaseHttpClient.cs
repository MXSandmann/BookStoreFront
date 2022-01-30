using BookStoreFront.Models.ApiResponses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BookStoreFront.HttpClients
{
    public abstract class BaseHttpClient
    {
        private HttpClient client;
        public BaseHttpClient(string baseUrl)
        {
            client = new HttpClient() { BaseAddress = new Uri(baseUrl) };
        }

        public virtual async Task<APIResponse<T>> GetAsync<T>(string url)
        {
            var response = await client.GetAsync(url);
            return JsonConvert.DeserializeObject<APIResponse<T>>(await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<APIResponse<T>> PostAsync<T>(string url, object body)
        {
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            return JsonConvert.DeserializeObject<APIResponse<T>>(await response.Content.ReadAsStringAsync());
        }

        public virtual async Task<ApiResponse> PostAsync(string url, object body)
        {
            var content = new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
            var response = await client.PostAsync(url, content);
            return JsonConvert.DeserializeObject<ApiResponse>(await response.Content.ReadAsStringAsync());
        }

    }
}
