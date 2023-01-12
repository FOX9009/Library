using Microsoft.EntityFrameworkCore;

namespace Library.Models
{
    public class LibContext : DbContext
    {
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public LibContext(DbContextOptions<LibContext> options) : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                 new User
                 {
                     Id = 1,
                     Name = "Никита"
                 },
                new User
                {
                    Id = 2,
                    Name = "Макс"
                }

                );
            modelBuilder.Entity<Book>().HasData(
                new Book
                {
                    Id = 1,
                    Title = "Ведьмак1",
                    Autor = "Сапковский",
                    Genre = "Фэнтези",
                    Description = "12356134gufherv",
                    Rating = 4.6,
                    IsRead = true,
                    UserID = 1
                },
                new Book
                {
                    Id = 2,
                    Title = "Ведьмак2",
                    Autor = "Сапковский",
                    Genre = "Фэнтези",
                    Description = "12356134gufherv",
                    Rating = 4.6,
                    IsRead = true,
                    UserID = 2
                },
                new Book
                {
                    Id = 3,
                    Title = "Ведьмак3",
                    Autor = "Сапковский",
                    Genre = "Фэнтези",
                    Description = "12356134gufherv",
                    Rating = 4.6,
                    IsRead = true,
                    UserID = 2
                }
                );
        }
    }
}
