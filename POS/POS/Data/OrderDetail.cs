namespace POS.Data
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double Discount { get; set; }
        public string ItemNote { get; set; }
        public Order Order { get; set; }
        public Meal Meal { get; set; }

    }
}