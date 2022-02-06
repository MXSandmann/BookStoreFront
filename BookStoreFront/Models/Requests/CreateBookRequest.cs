using System.Collections.Generic;

namespace BookStoreFront.Models.Requests
{
    public class CreateBookRequest
    {
        public string Title { get; set; }
        public double Price { get; set; }
        public List<int> Autors { get; set; }
        public List<int> Genres { get; set; }
    }
}
