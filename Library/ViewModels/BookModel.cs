namespace Library.ViewModels
{
    public record class BookModel (int Id, string Title, string Autor, string Genre, string Description, double Rating, bool IsRead, int? UserID);
    
}
