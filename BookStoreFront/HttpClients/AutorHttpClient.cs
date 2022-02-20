using BookStoreFront.Models.ApiResponses;
using BookStoreFront.Models.Requests;
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

        public async Task<APIResponse<int>> CreateAutor(string name, string surname)
        {
            var request = new CreateAutorRequest()
            {
                Name = name,
                Surname = surname
            };

            return await PostAsync<int>("api/autor/create", request);

        }

        public async Task<APIResponse<int>> DeleteAutor(int id)
        {
            var request = new DeleteAutorRequest()
            {
                Id = id
            };
            return await PostAsync<int>("api/autor/delete", request);
        }


    }
}
