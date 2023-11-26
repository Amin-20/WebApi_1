namespace WebApi_1.Dtos
{
    public class OrderUpdateDto
    {
        public DateTime? OrderTime { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
