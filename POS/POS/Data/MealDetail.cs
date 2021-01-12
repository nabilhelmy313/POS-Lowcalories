using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Data
{
    public class MealDetail
    {
        public int Id { get; set; }
        public string Quantity { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public Meal Meal { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }


    }
}
