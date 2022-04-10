﻿using BookStoreFront.Models.Responses.Autor;
using System.Collections.Generic;

namespace BookStoreFront.Models.Responses.Book
{
    public class BookDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int PagesCount { get; set; }
        public int Year { get; set; }
        public double Price { get; set; }
        public List<AutorDTO> Autors { get; set; }
        public List<string> Genres { get; set; }
    }
}
