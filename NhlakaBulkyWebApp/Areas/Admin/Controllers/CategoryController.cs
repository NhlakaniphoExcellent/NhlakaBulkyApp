using Microsoft.AspNetCore.Mvc;
using NhlakaBulkyWebApp.Data;
using NhlakaBulkyWebApp.Models;
using NhlakaBulky.DataAccess;
using NhlakaBulky.DataAccess.Repository.IRepository;

namespace NhlakaBulkyWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        // Dependency injection detected!!
        private readonly IUnitOfWork _unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            // we access sql database with the data context class hence I used "Categories"
            List<Category> categoryObjectList = _unitOfWork.categoryRepository.GetAll().ToList();
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
                _unitOfWork.categoryRepository.Add(category);
                _unitOfWork.Save();
                TempData["Created"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Category? categoryFromDB = _unitOfWork.categoryRepository.GetN(x => x.ID == Id);

            if (categoryFromDB == null)
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
                _unitOfWork.categoryRepository.Update(category);
                _unitOfWork.Save();
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
            Category? categoryFromDB = _unitOfWork.categoryRepository.GetN(x => x.ID == Id);

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

            Category? categoryFromDB = _unitOfWork.categoryRepository.GetN(x => x.ID == Id);
            if (categoryFromDB == null)
            {
                return NotFound();
            }
            _unitOfWork.categoryRepository.Remove(categoryFromDB);
            _unitOfWork.Save();
            TempData["Created"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
