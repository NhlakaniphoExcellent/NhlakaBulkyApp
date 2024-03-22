using Microsoft.AspNetCore.Mvc;
using NhlakaBulkyWebApp.Data;
using NhlakaBulkyWebApp.Models;

namespace NhlakaBulkyWebApp.Controllers
{
    public class CategoryController : Controller
    {
        // Dependency injection detected!!
        private readonly ApplicationDataContext _db;
        public CategoryController(ApplicationDataContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            // we access sql database with the data context class hence I used "Categories"
            List<Category> categoryObjectList = _db.Categories.ToList();
            return View(categoryObjectList);
        }

        public IActionResult Create()
        {
            return View();
        }
    }
}
