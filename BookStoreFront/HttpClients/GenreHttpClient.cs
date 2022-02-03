using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreFront.Models.ApiResponses;
using BookStoreFront.Models.Responses.Genre;

namespace BookStoreFront.HttpClients
{
    public class GenreHttpClient : BaseHttpClient
    {
        public GenreHttpClient(string url) : base(url)
        {
                
        }

        public async Task<APIResponse<ICollection<GenreDTO>>> GetAllGenres()
        {
            return await GetAsync<ICollection<GenreDTO>>("api/genre/get");
        }
    }
}
