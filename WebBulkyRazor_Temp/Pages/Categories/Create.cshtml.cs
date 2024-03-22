using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NhlakaBulkyWebApp.Models;
using WebBulkyRazor_Temp.Data;

namespace WebBulkyRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationRazorDataContext _db;
        [BindProperty]
        public Category Category { get; set; }
        public CreateModel(ApplicationRazorDataContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            _db.Categories.Add(Category);
            _db.SaveChanges();
            // we specify only action name in paranthesees because we are on the same folder
            return RedirectToPage("Index");
        }
    }
}
