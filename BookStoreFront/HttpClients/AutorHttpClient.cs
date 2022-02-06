using BookStoreFront.Models.ApiResponses;
using BookStoreFront.Models.Responses.Autor;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreFront.HttpClients
{
    public class AutorHttpClient : BaseHttpClient
    {
        public AutorHttpClient(string url) : base(url)  
        {

        }
        public async Task<APIResponse<ICollection<AutorDTO>>> GetAllAutors()
        {
            return await GetAsync<ICollection<AutorDTO>>("api/autor/get");
        }
    }
}
