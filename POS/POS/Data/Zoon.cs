using System.Collections.Generic;

namespace POS.Data
{
    public class Zoon
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Cost { get; set; }
        public ICollection<Address> Addresses{ get; set; }
    }
}