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
            var town = _db.Town.Select(x => x.TownName).Skip(1).ToList();
            ViewData["TownName"] = town;
            return View(Girls);
        }
        public IActionResult Booking()
        {
            var townGirls = _db.GirlProfile.Select(girl => girl.GirlName).ToList();

            ViewData["Girls"] = townGirls;
            var town = _db.Town.Select(x => x.TownName).Skip(1).ToList();
            ViewData["TownName"] = town;
            return View();
        }
        public IActionResult ThankYou()
        {
            return View();
        }
        public IActionResult Contact()
        {
            var town = _db.Town.Select(x => x.TownName).Skip(1).ToList();
            ViewData["TownName"] = town;
            return View();
        }

        public IActionResult Cities(int? TownId, int? MassageId)
        {
            var town = _db.Town.FirstOrDefault(t => t.TownID == TownId);
            var massage = _db.MassageType.FirstOrDefault(y => y.MassageTypeID == MassageId);
            var townGirls = _db.GirlProfile.Where(girl => girl.TownID == TownId).Select(girl => girl.GirlName).ToList();
            

            if (TownId == 4 || TownId == 5 || TownId == 8 || TownId == 10 || TownId == 14 || TownId == 16 || TownId == 17 || TownId == 18)
            {
                ViewData["Type"] = "true";
            }
            ViewData["Girls"] = townGirls;
            ViewData["PhoneCall"] = town.PhoneNumberCall;
            ViewData["PhoneShow"] = town.PhoneNumberStr;
            ViewData["TownId"] = town.TownID;
            ViewData["TownName"] = town.TownName;
            ViewData["MassageType"] = massage.TypeName;

            // Determine the appropriate header and footer based on MassageType
            string header = "";
            string footer = "";

            switch (MassageId)
            {
                case 1: // Assume MassageTypeID 1 corresponds to Erotic Massage
                    header = town.EroticHeader;
                    footer = town.EroticFooter;
                    break;

                case 2: // Assume MassageTypeID 2 corresponds to Asian Massage
                    header = town.HappyEndingHeader;
                    footer = town.HappyEndingFooter;
                    break;
                case 3:
                    header = town.TantraHeader;
                    footer = town.TantraFooter;
                    break;

                case 4: 
                    header = town.CouplesHeader;
                    footer = town.CouplesFooter;
                    break;
                case 5: 
                    header = town.AsianHeader;
                    footer = town.AsianFooter;
                    break;

                case 6: 
                    header = town.NuruHeader;
                    footer = town.NuruFooter;
                    break;
                case 7:
                    header = town.BodyHeader;
                    footer = town.BodyFooter;
                    break;

                case 8: 
                    header = town.SensualHeader;
                    footer = town.SensualFooter;
                    break;

                default:
                    break;
            }

            // Pass the header and footer to the view
            ViewData["Header"] = header;
            ViewData["Footer"] = footer;

            IEnumerable<GirlProfile> girls = _db.GirlProfile
                .Where(girl => girl.Town.TownID == TownId && girl.MassageTypeID == MassageId)
                .ToList();

            return View(girls);
        }
        public IActionResult OurMassageGirls()
        {
            IEnumerable<GirlProfile> Girls = _db.GirlProfile.Where(girl => girl.Town.TownName == "HOME");
            return View(Girls);
        }

    }
}
