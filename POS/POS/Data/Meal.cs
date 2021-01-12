using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Data
{
    public class Meal
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Photo { get; set; }
        public string Quantity { get; set; }
        public double? Price { get; set; }
        public bool HasSize { get; set; }
        public bool? IsChild { get; set; }
        public string color { get; set; }
        public bool delflage { get; set; }
        public int? ParentId { get; set; }
        public Category Category { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }

    }
}
