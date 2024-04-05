using Microsoft.AspNetCore.Mvc;
using NhlakaBulkyWebApp.Data;
using NhlakaBulkyWebApp.Models;
using NhlakaBulky.DataAccess;
using NhlakaBulky.DataAccess.Repository.IRepository;
using NhlakaWebApp.Models.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using NhlakaWebApp.Models.ViewModels;

namespace NhlakaBulkyWebApp.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        // Dependency injection detected!!
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // ViewBag : Transfers data from controller to view and not vice versa
        public IActionResult Index()
        {
            // we access sql database with the data context class hence I used "Categories"
            List<Product> productObjectList = _unitOfWork.productRepository.GetAll().ToList();
            return View(productObjectList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            // Here I am making a dropdownlist using IEnumerable
            IEnumerable<SelectListItem> categoryList = _unitOfWork.categoryRepository
                .GetAll().Select(x => new SelectListItem
                {
                    Text = x.Name,
                    Value = x.ID.ToString()
                });

            ViewBag.CategoryList = categoryList;
            ProductVM productVM = new ProductVM()
            {
                CategoryList = categoryList,
                Product = new Product()


            };
            return View(productVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductVM products)
        {
           

            /*   if (category.Name == category.DisplayOrder.ToString())
               {
                   ModelState.AddModelError("", "The Display Order cannot be the same as Catergory Name");
               } */

            if (ModelState.IsValid)
            {
                _unitOfWork.productRepository.Add(products.Product);
                _unitOfWork.Save();
                TempData["Created"] = "Product Created Successfully";
                return RedirectToAction("Index");
            }
            else
            {
                IEnumerable<SelectListItem> categoryList = _unitOfWork.categoryRepository
               .GetAll().Select(x => new SelectListItem
               {
                   Text = x.Name,
                   Value = x.ID.ToString()
               });
                ViewBag.CategoryList = categoryList;
                products.CategoryList = categoryList;
                return View(products);
            }
          
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            Product? productFromDB = _unitOfWork.productRepository.GetN(x => x.Id == Id);

            if (productFromDB == null)
            {
                return NotFound();
            }

            return View(productFromDB);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Product product)
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
                _unitOfWork.productRepository.Update(product);
                _unitOfWork.Save();
                TempData["Created"] = "Product Updated Successfully";
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
            Product? productFromDB = _unitOfWork.productRepository.GetN(x => x.Id == Id);

            if (productFromDB == null)
            {
                return NotFound();
            }

            return View(productFromDB);
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

            Product? productFromDB = _unitOfWork.productRepository.GetN(x => x.Id == Id);
            if (productFromDB == null)
            {
                return NotFound();
            }
            _unitOfWork.productRepository.Remove(productFromDB);
            _unitOfWork.Save();
            TempData["Created"] = "Product Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
