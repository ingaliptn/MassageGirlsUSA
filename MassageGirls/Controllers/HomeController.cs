using MassageGirls.Context;
using MassageGirls.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
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
            IEnumerable<GirlProfile> Girls = _db.GirlProfile.Where(girl => girl.Town.TownName == "HOME").Take(6);
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
        public IActionResult Cities()
        {
            ViewBag.City = "Atlanta";
            IEnumerable<GirlProfile> Girls = _db.GirlProfile.Where(girl => girl.Town.TownName == "ATLANTA" && girl.MassageTypeID == 1);
            return View(Girls);
        }
        public IActionResult OurMassageGirls()
        {
            IEnumerable<GirlProfile> Girls = _db.GirlProfile.Where(girl => girl.Town.TownName == "HOME");
            return View(Girls);
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
