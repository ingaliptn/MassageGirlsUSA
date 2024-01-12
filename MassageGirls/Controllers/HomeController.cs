using MassageGirls.Context;
using MassageGirls.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace MassageGirls.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db; 
        }

        public IActionResult Index()
        {
            IEnumerable<GirlProfile> Girls = _db.GirlProfile.Where(x => x.Town == "Home");
            return View(Girls);
        }
        public IActionResult Booking()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult OurMassageGirls()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
