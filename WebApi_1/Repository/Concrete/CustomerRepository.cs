using WebApi_1.Data;
using WebApi_1.Entities;
using WebApi_1.Repository.Abstract;

namespace WebApi_1.Repository.Concrete
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly ECommerceDbContext _context;

        public CustomerRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public void Add(Customer entity)
        {
            _context.Customers.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Customer entity)
        { 
            _context.Customers.Remove(entity);
            _context.SaveChanges();
        }

        public Customer Get(int id)
        {
            var customer = _context.Customers.SingleOrDefault(x => x.Id == id);
            return customer;
        }

        public IEnumerable<Customer> GetAll()
        {
            var customers = _context.Customers;
            return customers;
        }

        public void Update(Customer entity)
        {
            _context.Customers.Update(entity);
            _context.SaveChanges();
        }
    }
}
