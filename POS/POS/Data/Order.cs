using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.Data
{
    public class Order
    {
        public int Id { get; set; } //---ORDER NUMBER
        public int ResturantOrederId { get; set; } // THIS NUMBER Equivalent ORDER NUMBER
        public string Type { get; set; }
        public int Status { get; set; } //[HOLD - COOKING - DLIVERD]
        public string PamentMethod { get; set; }//[CASH - CARD]
        public DateTime OrderDate { get; set; }
        public DateTime ApproveDate { get; set; }
        public DateTime CookingTime { get; set; }
        public DateTime DiliveryTime { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }
        public double Net { get; set; }
        public double Service { get; set; }
        public string CustPhone { get; set; }
        public Address Address { get; set; }
        public Branch Branch { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
       
    }
}
