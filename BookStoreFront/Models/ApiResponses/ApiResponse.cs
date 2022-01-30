using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace BookStoreFront.Models.ApiResponses
{
    public class ApiResponse
    {
        [JsonProperty("code")]
        public int Code { get; set;  }
        public string ErrorMessage { get; set; }
        public bool Success { get; set; }
    }

    public class APIResponse<T> : ApiResponse
    {
        public T Data { get; set;  }
    }
}
