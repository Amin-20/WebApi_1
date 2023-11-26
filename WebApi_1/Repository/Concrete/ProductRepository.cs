using WebApi_1.Data;
using WebApi_1.Entities;
using WebApi_1.Repository.Abstract;

namespace WebApi_1.Repository.Concrete
{
    public class ProductRepository : IProductRepository
    {
        private readonly ECommerceDbContext _context;

        public ProductRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public void Add(Product entity)
        {
            _context.Products.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(Product entity)
        {
            _context.Products.Remove(entity);
            _context.SaveChanges();
        }

        public Product Get(int id)
        {
            var product = _context.Products.SingleOrDefault(x => x.Id == id);
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            var product = _context.Products;
            return product;
        }

        public void Update(Product entity)
        {
            _context.Products.Update(entity);
            _context.SaveChanges();
        }
    }
}
