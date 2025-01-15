using Entity;

namespace eCommerce.Repositories
{
    public interface ICategoryRepository
    {
        List<Category> GetCategories();
        void AddCategory(Category category);
        void EditCategory(Category category);

        bool DeleteCategoryPOST(int id);

        Category FindCategory(int? id);

        void Save();
    }
}



