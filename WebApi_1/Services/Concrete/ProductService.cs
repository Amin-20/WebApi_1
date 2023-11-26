using WebApi_1.Entities;
using WebApi_1.Repository.Abstract;
using WebApi_1.Services.Abstract;

namespace WebApi_1.Services.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void Add(Product entity)
        {
            _productRepository.Add(entity);
        }

        public void Delete(int id)
        {
            var order = _productRepository.Get(id);
            _productRepository.Delete(order);
        }

        public Product Get(int id)
        {
            return _productRepository.Get(id);
        }

        public IEnumerable<Product> GetAll()
        {
            return _productRepository.GetAll();
        }

        public void Update(Product entity)
        {
            _productRepository.Update(entity);
        }
    }
}
