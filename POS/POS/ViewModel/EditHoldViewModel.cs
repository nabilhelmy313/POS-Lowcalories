using POS.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace POS.ViewModel
{
    public class EditHoldViewModel
    {
        public Order Orders { get; set; }
        public int Id { get; set; } //---ORDER NUMBER
        public int ResturantOrederId { get; set; } // THIS NUMBER Equivalent ORDER NUMBER
        public string Type { get; set; }
        public int Status { get; set; } //[HOLD - COOKING - DLIVERD]
        public DateTime OrderDate { get; set; }
        public int CookingTime { get; set; }
        public int DiliveryTime { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double Total { get; set; }

    }
}
