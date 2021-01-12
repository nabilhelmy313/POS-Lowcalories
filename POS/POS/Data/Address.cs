namespace POS.Data
{
    public class Address
    {
        public int Id { get; set; }
        public string Floor { get; set; }
        public string Street { get; set; }
        public string Flat { get; set; }
        public string Landmark { get; set; }
        public Zoon Zoon { get; set; }
        public Customer Customer { get; set; }

    }
}