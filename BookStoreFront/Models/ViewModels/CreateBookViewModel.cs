using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace BookStoreFront.Models.ViewModels
{
    public class CreateBookViewModel
    {
        public string Title { get; set; }
        public int Autor { get; set; }
        public int Genre { get; set; }
        public string Price { get; set; }

        public IEnumerable<SelectListItem> Autors { get; set; }
        public IEnumerable<SelectListItem> Genres { get; set; } 
    }
}
