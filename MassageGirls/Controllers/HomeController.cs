using MassageGirls.Context;
using MassageGirls.Models;
using Microsoft.AspNetCore.Mvc;

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
            IEnumerable<GirlProfile> Girls = _db.GirlProfile.Where(girl => girl.Town.TownName == "Home").Take(6);
            var town = _db.Town.Select(x => x.TownName).Skip(1).ToList();
            ViewData["TownName"] = town;
            return View(Girls);
        }
       
        [HttpGet("/Booking", Name = "Booking")]
        public IActionResult Booking()
        {
            var townGirls = _db.GirlProfile.Select(girl => girl.GirlName).ToList();

            ViewData["Girls"] = townGirls;
            var town = _db.Town.Select(x => x.TownName).Skip(1).ToList();
            ViewData["TownName"] = town;
            return View();
        }
       
        [HttpGet("/ThankYou", Name = "ThankYou")]
        public IActionResult ThankYou()
        {
            return View();
        }
       
        [HttpGet("/Contact", Name = "Contact")]
        public IActionResult Contact()
        {
            var town = _db.Town.Select(x => x.TownName).Skip(1).ToList();
            ViewData["TownName"] = town;
            return View();
        }
        
        [HttpGet("/Error", Name = "Error")]
        public IActionResult Error(int? statusCode = null)
        {
            if (statusCode.HasValue)
            {
                if (statusCode.Value == 404)
                {
                    // Redirect to home page for 404 errors
                    return RedirectToAction("Index", "Home");
                }
                // Handle other errors or display a generic error page
            }

            return View();
        }

        [HttpGet("/OurMassageGirls", Name = "OurMassageGirls")]
        public IActionResult OurMassageGirls()
        {
            IEnumerable<GirlProfile> Girls = _db.GirlProfile.Where(girl => girl.Town.TownName == "Home");
            return View(Girls);
        }
       
    }
}
