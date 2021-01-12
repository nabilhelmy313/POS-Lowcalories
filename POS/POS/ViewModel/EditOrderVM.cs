using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class EditOrderVM
    {
        public List<Category> Categories { get; set; }
        public List<Meal> Meals { get; set; }
        public List<Address> Addresses { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public List<Order> Orders { get; set; }
        public List<OrderdetailVM> OrderdetailVMs { get; set; }
        public Order Order { get; set; }
        public string Type { get; set; }
        public string Phone { get; set; }
        public int OrderId { get; set; }
        public int BranchId { get; set; }
        public int AddressId { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public double Net { get; set; }
        public double Service { get; set; }
        public List<Branch> Branches { get; internal set; }
    }
}
