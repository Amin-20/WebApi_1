using WebApi_1.Entities;
using WebApi_1.Repository.Abstract;
using WebApi_1.Services.Abstract;

namespace WebApi_1.Services.Concrete
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public void Add(Order entity)
        {
            _orderRepository.Add(entity);
        }

        public void Delete(int id)
        {
            var order = _orderRepository.Get(id);
            _orderRepository.Delete(order);
        }

        public Order Get(int id)
        {
            return _orderRepository.Get(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return _orderRepository.GetAll();
        }

        public void Update(Order entity)
        {
            _orderRepository.Update(entity);
        }
    }
}
