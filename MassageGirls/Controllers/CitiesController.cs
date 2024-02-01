using MassageGirls.Context;
using MassageGirls.Models;
using Microsoft.AspNetCore.Mvc;

namespace MassageGirls.Controllers
{
    public class CitiesController : Controller
    {
        private readonly AppDbContext _db;
        public CitiesController(AppDbContext bd)
        {
            _db = bd;
        }

        [HttpGet("{townName}/{UrlName?}/", Name = "Cities")]
        public IActionResult Cities(string townName, string? UrlName)
        {
            if (UrlName == null)
                UrlName = "erotic"; 
            

            var town = _db.Town.FirstOrDefault(t => t.TownName == townName);
            var massage = _db.MassageType.FirstOrDefault(y => y.UrlName == UrlName);

            if (town == null || massage == null)
            {
                // Handle the case where town or massage is not found
                return NotFound();
            }

            SetViewDataForCity(town);
            SetHeaderAndFooterBasedOnMassageType(town, massage.MassageTypeID);

            IEnumerable<GirlProfile> girls = _db.GirlProfile
                .Where(girl => girl.Town.TownID == town.TownID && girl.MassageTypeID == massage.MassageTypeID)
                .ToList();

            ViewData["MassageType"] = massage.TypeName;
            ViewData["UrlName"] = UrlName; // Pass UrlName to the view

            return View(girls);
        }

        private void SetViewDataForCity(Town town)
        {
            ViewData["Girls"] = _db.GirlProfile
                .Where(girl => girl.TownID == town.TownID)
                .Select(girl => girl.GirlName)
                .ToList();

            ViewData["PhoneCall"] = town.PhoneNumberCall;
            ViewData["PhoneShow"] = town.PhoneNumberStr;
            ViewData["TownId"] = town.TownID;
            ViewData["TownName"] = town.TownName;
        }

        private void SetHeaderAndFooterBasedOnMassageType(Town town, int? MassageId)
        {
            string header = "";
            string footer = "";

            switch (MassageId)
            {
                case 1: header = town.EroticHeader; footer = town.EroticFooter; break;
                case 2: header = town.HappyEndingHeader; footer = town.HappyEndingFooter; break;
                case 3: header = town.TantraHeader; footer = town.TantraFooter; break;
                case 4: header = town.CouplesHeader; footer = town.CouplesFooter; break;
                case 5: header = town.AsianHeader; footer = town.AsianFooter; break;
                case 6: header = town.NuruHeader; footer = town.NuruFooter; break;
                case 7: header = town.BodyHeader; footer = town.BodyFooter; break;
                case 8: header = town.SensualHeader; footer = town.SensualFooter; break;
                default: break;
            }

            // Pass the header and footer to the view
            ViewData["Header"] = header;
            ViewData["Footer"] = footer;

            if (new[] { 4, 5, 8, 10, 14, 16, 17, 18 }.Contains(town.TownID))
            {
                ViewData["Type"] = "true";
            }
        }

    }
}
