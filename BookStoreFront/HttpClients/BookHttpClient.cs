using BookStoreFront.Models.ApiResponses;
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

    }
}
