using Microsoft.AspNetCore.Http;
using POS.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class AddMealViewModel
    {
        public IEnumerable<Category> Categories{ get; set; }
        public IEnumerable<Meal> Meals { get; set; }
        public int MealId { get; set; }
        [Required(ErrorMessage ="Meal NAME IS REQUIRED")]
        [Display(Name="Meal Name")]
        public string Name { get; set; }
        public string Quantity { get; set; }
        public double? Price { get; set; }
        public bool HasSize { get; set; }
        public bool? IsChild { get; set; }

        public int? ParentId { get; set; }
        public string Note { get; set; }

        [Display(Name = "Meal Picture")]
        public IFormFile MealImage { get; set; }
        public Category Category { get; set; }
    }
}
