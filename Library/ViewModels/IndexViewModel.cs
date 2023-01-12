using Library.Models;

namespace Library.ViewModels
{
    public class IndexViewModel
    {
        public IEnumerable<Book> Books { get; set; } = new List<Book>();
        public IEnumerable<UserModel> Users { get; set; } = new List<UserModel>();
        public IEnumerable<BookModel> BookModels { get; set; } = new List<BookModel>();
    }
}
