using DataAccess.Contexts;
using eCommerce.Repositories;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("admin")]
    public class CategoryController : Controller
    {

        void isValid(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "cannot be exactly same Name and Display Order");
            }
        }

        private readonly ICategoryRepository _categoryRepository;
        public CategoryController(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public List<Category> categories { get; set; }

        public IActionResult Index()
        {
            categories = _categoryRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            int notificationCounter = 0;
            isValid(category);
            if (ModelState.IsValid)
            {
                _categoryRepository.AddCategory(category);
                _categoryRepository.Save();
                if (notificationCounter < 1)
                {
                    TempData["message"] = "Category has been added";
                    notificationCounter++;
                }
                return RedirectToAction("Index", "Category");
            }
            return View();
        }


        public IActionResult Edit(int? id)
        {
            var category = _categoryRepository.FindCategory(id);
            if (id == null || id == 0 || category == null)
            {
                return NotFound();
            }
            return View(category);
        }


        [HttpPost]
        public IActionResult Edit(Category category)
        {
            isValid(category);

            if (ModelState.IsValid)
            {
                _categoryRepository.EditCategory(category);
                _categoryRepository.Save();
                TempData["message"] = "Category has been edited";
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            var category = _categoryRepository.FindCategory(id);
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int id)
        {
            var isDeleted = _categoryRepository.DeleteCategoryPOST(id);
            if (isDeleted)
            {
                _categoryRepository.Save();
                TempData["message"] = "Category has been removed";
                return RedirectToAction("Index", "Category");
            }
            return RedirectToAction("Delete");
        }

    }
}
