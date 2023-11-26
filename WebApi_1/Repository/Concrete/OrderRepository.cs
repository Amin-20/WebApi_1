using WebApi_1.Data;
using WebApi_1.Entities;
using WebApi_1.Repository.Abstract;

namespace WebApi_1.Repository.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ECommerceDbContext _context;

        public OrderRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public void Add(Order entity)
        {
            _context.Orders.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Order entity)
        {
            _context.Orders.Remove(entity);
            _context.SaveChanges();
        }

        public Order Get(int id)
        {
            var order = _context.Orders.SingleOrDefault(x => x.Id == id);
            return order;
        }

        public IEnumerable<Order> GetAll()
        {
            var order = _context.Orders;
            return order;
        }

        public void Update(Order entity)
        {
            _context.Orders.Update(entity);
            _context.SaveChanges();
        }
    }
}
