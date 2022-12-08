using Microsoft.AspNetCore.Mvc;
using ReportServices.Entity;
using System.Linq;

namespace ReportServices.Controllers
{
    public class HomeController : Controller
    {
        private Context _context;
        public HomeController(Context context )
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.PhoneReports.ToList());
        }
    }
}
