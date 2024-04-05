using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NhlakaBulkyWebApp.Models;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace NhlakaWebApp.Models.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
       
        public string Title { get; set; }
        [Required]
   
        public string Description { get; set; }
        [Required]
        
        public string ISBN { get; set; }
        [Required]
    
        public string Author { get; set; }

        [Required]
        [DisplayName("List Price")]
        [Range(1, 5000)]
      
        // price of product
        public double ListPrice { get; set; }
        [Required]
        [DisplayName("Price for 1-50")]
        [Range(1, 50)]

        // price of product when the quantity is between 1-50 books
        public double Price { get; set; }
        [Required]
        [DisplayName("Price for 50-100")]
        [Range(1, 100)]
      
        // price of product when the quantity is between 50-100 books
        public double Price50 { get; set; }
        [Required]
        [DisplayName("Price for 100+")]
        [Range(1, 5000)]

        // price of product when the quantity is between 100+ books
        public double Price100 { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImageURL { get; set; }
    }
}
