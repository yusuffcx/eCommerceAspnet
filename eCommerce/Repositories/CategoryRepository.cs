using DataAccess.Contexts;
using Entity;

namespace eCommerce.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _context;

        public CategoryRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
        }

        public bool DeleteCategoryPOST(int id)
        {
            var category = FindCategory(id);
            if(category!= null)
            {
                _context.Categories.Remove(category);
                return true;
            }
            else
            {
                return false;
            }
        }

        public void EditCategory(Category category)
        {
            _context.Categories.Update(category);
        }

        public Category FindCategory(int? id)
        {
            var category = _context.Categories.Find(id);
            return category;
        }

        public List<Category> GetCategories()
        {
            var Categories = _context.Categories.ToList();
            return Categories;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

    }
}
