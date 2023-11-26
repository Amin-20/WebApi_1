namespace WebApi_1.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public int Discount  { get; set; }

        public ICollection<Order>? Orders { get; set; }
    }
}
