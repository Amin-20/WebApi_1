namespace WebApi_1.Dtos
{
    public class OrderAddDto
    {
        public DateTime? OrderTime { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
    }
}
