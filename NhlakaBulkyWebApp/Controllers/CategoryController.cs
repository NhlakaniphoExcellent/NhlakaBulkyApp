using Microsoft.AspNetCore.Mvc;
using NhlakaBulkyWebApp.Data;
using NhlakaBulkyWebApp.Models;
using NhlakaBulky.DataAccess;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("", "The Display Order cannot be the same as Catergory Name");
            }

            /*   if (category.Name == category.DisplayOrder.ToString())
               {
                   ModelState.AddModelError("", "The Display Order cannot be the same as Catergory Name");
               } */

            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                TempData["Created"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if(Id == null || Id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDB = _db.Categories.FirstOrDefault(x => x.ID == Id);

            if(categoryFromDB == null)
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category category)
        {
            //if (category.Name == category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("", "The Display Order cannot be the same as Catergory Name");
            //}
            /*   if (category.Name == category.DisplayOrder.ToString())
               {
                   ModelState.AddModelError("", "The Display Order cannot be the same as Catergory Name");
               } */
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                TempData["Created"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Delete(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDB = _db.Categories.FirstOrDefault(x => x.ID == Id);

            if (categoryFromDB == null)
            {
                return NotFound();
            }

            return View(categoryFromDB);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? Id)
        {
            //if (category.Name == category.DisplayOrder.ToString())
            //{
            //    ModelState.AddModelError("", "The Display Order cannot be the same as Catergory Name");
            //}
            /*   if (category.Name == category.DisplayOrder.ToString())
               {
                   ModelState.AddModelError("", "The Display Order cannot be the same as Catergory Name");
               } */

            Category? categoryFromDB = _db.Categories.FirstOrDefault(x => x.ID == Id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryFromDB);
            _db.SaveChanges();
            TempData["Created"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
