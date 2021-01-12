using System.Collections.Generic;

namespace POS.Data
{
    public class Branch
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Phone1 { get; set; }
        public string Phone2 { get; set; }
        public string Address { get; set; }
        public ICollection<Order> Orders{ get; set; }
    }
}