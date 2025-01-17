using Entity;

namespace eCommerce.Repositories
{
    public interface IProductRepository
    {
        public List<Product> GetAll();

        public void Add(Product product);

        public Product GetById(int id);

        public void Edit(Product product);

        public void Delete(Product product);

        public void Save();


    }

}
