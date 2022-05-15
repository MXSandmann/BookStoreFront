using BookStoreFront.HttpClients;
using BookStoreFront.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreFront.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private BookHttpClient _bookHttpClient;

        public HomeController(ILogger<HomeController> logger, BookHttpClient bookHttpClient)
        {
            _logger = logger;
            _bookHttpClient = bookHttpClient;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _bookHttpClient.GetAllBooks();

            ViewData["isDescription"] = true;
            ViewData["Description"] = "Blablabla";
            ViewBag.FreeText = "i dont know";

            if (result.Success)
                return View(result.Data);
            else
                return RedirectToAction("Error");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
