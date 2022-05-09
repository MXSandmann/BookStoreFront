using BookStoreFront.HttpClients;
using BookStoreFront.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
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

        [HttpPost]
        public async Task<IActionResult> CreateBook(CreateBookViewModel model)
        {
            var result = await _bookHttpClient.CreateBook(model.Title, 
                model.Autor,
                model.Genre,
                double.Parse(model.Price, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture),
                model.PagesCount,
                model.Year);
            if (result.Success)
                return RedirectToAction("Index", "Admin");
            else
                return RedirectToAction("Error", "Home");
        }

        public ViewResult CreateAutor()
        {
            return View(new CreateAutorViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateAutor(CreateAutorViewModel model)
        {
            var result = await _autorHttpClient.CreateAutor(model.Name, model.Surname);
            if (result.Success)
                return RedirectToAction("Index", "Admin");
            else
                return RedirectToAction("Error", "Home");
        }


        [HttpGet]
        public async Task<IActionResult> GetAllAutors()
        {
            var result = await _autorHttpClient.GetAllAutors();
            if (result.Success)
                return View(result.Data);
            else
                return RedirectToAction("Error");
        }

        public ViewResult CreateGenre()
        {
            return View(new CreateGenreViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> CreateGenre(CreateGenreViewModel model)
        {
            var result = await _genreHttpClient.CreateGenre(model.Name);
            if (result.Success)
                return RedirectToAction("Index", "Admin");
            else
                return RedirectToAction("Error", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGenres()
        {
            var result = await _genreHttpClient.GetAllGenres();
            if (result.Success)
                return View(result.Data);
                
            else
                return RedirectToAction("Error");
        }

        
        //[HttpDelete]
        public async Task<IActionResult> DeleteAutor(int id)
        {
            var deletedAutorId = await _autorHttpClient.DeleteAutor(id);
            
            if (deletedAutorId.Success)
                return RedirectToAction("Index", "Admin");
            else
                return RedirectToAction("Error");
        }

        //[HttpDelete]
        public async Task<IActionResult> DeleteBook()
        {
            throw new NotImplementedException();
        }

        // Update get
        [HttpGet("get/{id}")]
        public async Task<IActionResult> UpdateBook(int id)
        {

            var result = await _bookHttpClient.GetBookById(id);
            if (result.Success)
                return View("UpdateBook", new UpdateBookViewModel()
                {
                    Title = result.Data.Title,
                    Price = result.Data.Price.ToString(),
                    PagesCount = result.Data.PagesCount,
                    Year = result.Data.Year,
                });
            else
                return RedirectToAction("Error");
            
        }

        // Update post
        [HttpPost("get/{id}")]

        
        public async Task<IActionResult> UpdateBook(UpdateBookViewModel model, int id)
        {
            var result = await _bookHttpClient
                .UpdateBook(id, model.Title, double.Parse(model.Price, System.Globalization.NumberStyles.Any, CultureInfo.InvariantCulture), model.PagesCount, model.Year);
            if (result.Success)
                return RedirectToAction("Index", "Admin");
            else
                return RedirectToAction("Error", "Home");
        }
    }
}
