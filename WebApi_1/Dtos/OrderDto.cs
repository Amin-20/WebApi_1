namespace WebApi_1.Dtos
{
    public class OrderDto
    {
        public int Id { get; set; }
        public DateTime? OrderTime { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
