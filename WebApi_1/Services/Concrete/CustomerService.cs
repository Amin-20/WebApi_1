using WebApi_1.Data;
using WebApi_1.Entities;
using WebApi_1.Repository.Abstract;
using WebApi_1.Services.Abstract;

namespace WebApi_1.Services.Concrete
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public void Add(Customer entity)
        {
            _customerRepository.Add(entity);
        }

        public void Delete(int id)
        {
            var customer = _customerRepository.Get(id);
            _customerRepository.Delete(customer);
        }

        public Customer Get(int id)
        {
            return _customerRepository.Get(id);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customerRepository.GetAll();
        }

        public void Update(Customer entity)
        {
            _customerRepository.Update(entity);
        }
    }
}
