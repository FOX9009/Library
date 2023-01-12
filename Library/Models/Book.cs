namespace Library.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Autor { get; set; }
        public string Genre { get; set; }
        public string Description { get; set; }
        public double Rating { get; set; }
        public bool IsRead { get; set; }
        public int? UserID { get; set; }
        public User User { get; set; }

    }
}
