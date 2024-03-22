using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NhlakaBulkyWebApp.Data;
using NhlakaBulkyWebApp.Models;
using WebBulkyRazor_Temp.Data;

namespace WebBulkyRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationRazorDataContext _db;
        public List<Category> CategoryList { get; set; }
        public IndexModel(ApplicationRazorDataContext db)
        {
            _db = db;
        }

        // Dont have to write return statement for void functions
        public void OnGet()
        {
            CategoryList = _db.Categories.ToList();
        }
    }
}
