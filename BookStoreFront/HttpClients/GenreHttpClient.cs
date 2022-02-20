using System.Collections.Generic;
using System.Threading.Tasks;
using BookStoreFront.Models.ApiResponses;
using BookStoreFront.Models.Requests;
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

        public async Task<APIResponse<int>> CreateGenre(string name)
        {
            var request = new CreateGenreRequest()
            {
                Name = name,
                
            };

            return await PostAsync<int>("api/genre/create", request);

        }
    }
}
