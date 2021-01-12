using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class OrderViewModel
    {
        public List<Category> Categories{ get; set; }
        public List<Meal> Meals { get; set; }
        public List<Address> Addresses { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Order> Orders { get; set; }
        public Customer Customer { get; set; }
        public Order Order { get; set; }
        public int BranchId { get; set; }
        public List<Branch> Branches { get; internal set; }
        public string UserId { get; internal set; }
    }
}
