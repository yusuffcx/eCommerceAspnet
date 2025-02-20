using DataAccess.Contexts;
using Entity;
using Microsoft.AspNetCore.Mvc;

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

    }
}
