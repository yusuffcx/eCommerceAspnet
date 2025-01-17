using Entity;

namespace eCommerce.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IProductRepository _db;
        public ProductRepository(IProductRepository repository)
        {
            _db = repository;
        }

        public void Add(Product product)
        {
        }

        public void Delete(Product product)
        {
            _db.Delete(product);
        }

        public void Edit(Product product)
        {
            _db.Edit(product);
        }

        public List<Product> GetAll()
        {
            throw new NotImplementedException();
        }

        public Product GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
