using BookStoreFront.Models.ApiResponses;
using BookStoreFront.Models.Requests;
using BookStoreFront.Models.Responses.Book;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreFront.HttpClients
{
    public class BookHttpClient : BaseHttpClient
    {
        public BookHttpClient(string url) : base(url)
        {

        }

        public async Task<APIResponse<ICollection<BookDTO>>> GetAllBooks()
        {
            return await GetAsync<ICollection<BookDTO>>("api/book/get");
        }

        public async Task<APIResponse<int>> CreateBook(string title, int autorID, int genreID, double price)
        {
            var request = new CreateBookRequest()
            {
                Title = title,
                Autors = new List<int> { autorID },
                Genres = new List<int> { genreID },
                Price = price
            };

            return await PostAsync<int>("api/book/create", request);

        }

    }
}
