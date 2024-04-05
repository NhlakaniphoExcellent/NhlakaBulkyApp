using NhlakaWebApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SelectListItem = Microsoft.AspNetCore.Mvc.Rendering.SelectListItem;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

// using Microsoft.AspNetCore.Mvc.Rendering;


namespace NhlakaWebApp.Models.ViewModels
{
    // View models (aka strongly typed views) are views that are specifically designed for a model
    public class ProductVM
    {
        public Product Product { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> CategoryList { get; set; }
    }
}
