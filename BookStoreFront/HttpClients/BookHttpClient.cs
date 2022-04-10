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

        public async Task<APIResponse<int>> CreateBook(string title,
            int autorID,
            int genreID,
            double price, 
            int pagesCount,
            int year)
        {
            var request = new CreateBookRequest()
            {
                Title = title,
                Autors = new List<int> { autorID },
                Genres = new List<int> { genreID },
                Price = price,
                Year = year,
                PagesCount = pagesCount
            };

            return await PostAsync<int>("api/book/create", request);

        }

        public async Task<APIResponse<BookDTO>> GetBookById(int id)
        {
            return await GetAsync<BookDTO>($"api/book/get/{id}");
        }

        public async Task<APIResponse<int>> UpdateBook(string title,           
            double price,
            int pagesCount,
            int year)
        {
            var request = new CreateBookRequest()
            {
                Title = title,                
                Price = price,
                Year = year,
                PagesCount = pagesCount
            };

            return await PostAsync<int>("api/book/update", request);

        }

    }
}
