using DataAccess.Contexts;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CompanyController : Controller
    {
        private readonly AppDbContext _context;

        public CompanyController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            List<Company> companies = _context.Companies.ToList();

            return View(companies);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Company company)
        {
            _context.Companies.Add(company);
            _context.SaveChanges();
            return RedirectToAction("Index","Company");
        }

        public IActionResult Edit(int id)
        {
            var company = _context.Companies.Find(id);
            return View(company);
        }

        [HttpPost]
        public IActionResult Edit(Company company)
        {
            _context.Companies.Update(company);
            _context.SaveChanges();

            return RedirectToAction("Index", "Company");
        }

        
        public IActionResult Delete(int id)
        {
            var com = _context.Companies.Find(id);
            _context.Companies.Remove(com);
            _context.SaveChanges();
            return RedirectToAction("Index","Company");
        }



    }
}
