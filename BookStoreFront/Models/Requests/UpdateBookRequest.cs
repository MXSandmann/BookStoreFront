namespace BookStoreFront.Models.Requests
{
    public class UpdateBookRequest
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public int PagesCount { get; set; }
        public int Year { get; set; }
    }
}
