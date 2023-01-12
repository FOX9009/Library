using Microsoft.EntityFrameworkCore;
using Library.Models;
using Microsoft.AspNetCore.Mvc;
using Library.ViewModels;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        private readonly ILogger<BookController> _logger;

        LibContext db;
        public BookController(LibContext context, ILogger<BookController> logger)
        {
            _logger = logger;
            db = context;
        }
        public async  Task<IActionResult> Index()
        {
            return View(await db.Books.ToListAsync());
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            List<UserModel> userModels = db.Users.Select(u => new UserModel(u.Id, u.Name)).ToList();
            IndexViewModel viewModel = new()
            {
                Users = userModels
            };

            


            db.Books.Add(book);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id != null)
            {
                Book? book = await db.Books.FirstOrDefaultAsync(p => p.Id == id);
                if (book != null)
                {
                    db.Books.Remove(book);
                    await db.SaveChangesAsync();
                    return RedirectToAction("Index");
                }
            }
            return NotFound();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id != null)
            {
                Book? book = await db.Books.FirstOrDefaultAsync(p => p.Id == id);
                if (book != null) return View(book);
            }
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            db.Books.Update(book);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
    }
}