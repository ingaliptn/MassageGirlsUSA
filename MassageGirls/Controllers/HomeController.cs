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
            ViewData["Title"] = "Welcome To Massage Girls Online";
            ViewData["Content"] = "We offer exceptoonal massage services in many cities of the United States - Massage Girls Online.";


            return View(Girls);
        }
       
        [HttpGet("/booking", Name = "Booking")]
        public IActionResult Booking()
        {
            var townGirls = _db.GirlProfile.Select(girl => girl.GirlName).ToList();

            ViewData["Girls"] = townGirls;
            var town = _db.Town.Select(x => x.TownName).Skip(1).ToList();
            ViewData["TownName"] = town;
            
            ViewData["Title"] = "Booking Form | Massage Girls Online";
            ViewData["Content"] = "Schedule an appointment using our online form. We are waiting for your enquires 24/7 - Massage Girls Online.";
            ViewData["Url"] = "booking/";


            return View();
        }
       
        [HttpGet("/thankyou", Name = "ThankYou")]
        public IActionResult ThankYou()
        {
            return View();
        }
       
        [HttpGet("/contact", Name = "Contact")]
        public IActionResult Contact()
        {
            var town = _db.Town.Select(x => x.TownName).Skip(1).ToList();
            ViewData["TownName"] = town;

            ViewData["Title"] = "Contact Us | Massage Girls Online";
            ViewData["Content"] = "Contact us 24/7 - Massage Girls Online.";
            ViewData["Url"] = "contact/";
            return View();
        }
        
        [HttpGet("/error", Name = "Error")]
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

        [HttpGet("/our-girls", Name = "OurMassageGirls")]
        public IActionResult OurMassageGirls()
        {
            IEnumerable<GirlProfile> Girls = _db.GirlProfile.Where(girl => girl.Town.TownName == "Home");
            ViewData["Title"] = "All Our Featured Girls | Massage Girls Online";
            ViewData["Content"] = "Look at the galery of our featured massage girls available in different cities - Massage Girls Online.";
            ViewData["Url"] = "our-girls/";
            return View(Girls);
        }
       
    }
}
