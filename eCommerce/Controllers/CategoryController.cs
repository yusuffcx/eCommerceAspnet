﻿using eCommerce.Contexts;
using eCommerce.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Controllers
{
    public class CategoryController : Controller
    {

        void isValid(Category category)
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "cannot be exactly same Name and Display Order");
            }
        }

        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public List<Category>categories { get; set; }
        public IActionResult Index()
        {
            categories = _context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category category)
        {
            isValid(category);
            if(ModelState.IsValid)
            {
                _context.Categories.Add(category);
                _context.SaveChanges();

                return RedirectToAction("Index","Category");
            }
            return View();
        }
        public IActionResult Edit(int ?id)
        {
            var category = _context.Categories.Find(id);
            if(id== null ||id== 0 || category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            isValid(category);

            if(ModelState.IsValid)
            {
                _context.Categories.Update(category);
                _context.SaveChanges();
                return RedirectToAction("Index", "Category");
            }
            return View();
        }

        public IActionResult Delete(int id)
        {
            _context.Categories.Where(c => c.Id == id).ExecuteDelete();
            _context.SaveChanges();
            return RedirectToAction("Index", "Category");
        }

    }
}
