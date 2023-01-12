using Library.Models;
using Library.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.EntityFrameworkCore;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        LibContext db;

        public HomeController(ILogger<HomeController> logger, LibContext context)
        {
            db = context;
            _logger = logger;
        }

        public IActionResult Index (int? userId)
        {
            List<UserModel> userModels = db.Users.Select(u => new UserModel(u.Id, u.Name)).ToList();
            userModels.Insert(0, new UserModel(0, "Все"));

            IndexViewModel viewModel = new()
            {
                Users = userModels,
                Books = db.Books
            };

            if (userId != null && userId > 0)
                viewModel.Books = db.Books.Where(b => b.User.Id == userId);

            return View(viewModel);
        }

        

        
    }
}