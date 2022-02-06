using BookStoreFront.HttpClients;
using BookStoreFront.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreFront.Controllers
{
    public class AdminController : Controller
    {
        private BookHttpClient _bookHttpClient;
        private GenreHttpClient _genreHttpClient;
        private AutorHttpClient _autorHttpClient;
        public AdminController(BookHttpClient bookHttpClient, GenreHttpClient genreHttpClient, AutorHttpClient autorHttpClient) 
        {
            _bookHttpClient = bookHttpClient;
            _genreHttpClient = genreHttpClient;
            _autorHttpClient = autorHttpClient;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _bookHttpClient.GetAllBooks();
            if (result.Success)
                return View(result.Data);
            else
                return RedirectToAction("Error");
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookViewModel model)
        {
            var result = await _bookHttpClient.CreateBook(model.Title, model.Autor, model.Genre, double.Parse(model.Price, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture));
            if (result.Success)
                return RedirectToAction("Index", "Admin");
            else
                return RedirectToAction("Error", "Home");
        }

        public async Task<IActionResult> CreateBook()
        {   
            var autors = await _autorHttpClient.GetAllAutors();
            var genres = await _genreHttpClient.GetAllGenres();

            var autorSelectList = autors.Data.Select(x => new SelectListItem(x.Name + " " + x.Surname, x.ID.ToString()));
            var genreSelectList = genres.Data.Select(x => new SelectListItem(x.Name, x.ID.ToString()));

            var createBookViewModel = new CreateBookViewModel()
            {
                Autors = autorSelectList,
                Genres = genreSelectList,

            };
            return View(createBookViewModel);
        }
    }
}
