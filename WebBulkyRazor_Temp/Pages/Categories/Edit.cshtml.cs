using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NhlakaBulkyWebApp.Models;
using WebBulkyRazor_Temp.Data;

namespace WebBulkyRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationRazorDataContext _db;
        
        public Category Category { get; set; }
        public EditModel(ApplicationRazorDataContext db)
        {
            _db = db;
        }
        public void OnGet(int? id)
        {
            if(id == null && id != 0)
            {
                Category = _db.Categories.Find(Category.ID);
            }
        }

        public IActionResult OnPost()
        {
            Category = _db.Categories.Find(Category.ID);
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
           return Page();
        }
    }
}
