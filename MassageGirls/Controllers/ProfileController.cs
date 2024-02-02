using MassageGirls.Context;
using MassageGirls.Models;
using Microsoft.AspNetCore.Mvc;

namespace MassageGirls.Controllers
{
    public class ProfileController : Controller
    {
        private readonly AppDbContext _db;
        public ProfileController(AppDbContext bd)
        {
            _db = bd;
        }

        [HttpGet("{townName?}/profile/{girlName}/", Name = "Profile")]
        public IActionResult Profile(string girlName, string? townName)
        {
            if (townName == null)
                townName = "home";

            int? girlId = GetGirlIdByNameAndTown(townName, girlName);
            int? townId = GetTownIdByName(townName);

            if (girlId.HasValue && townId.HasValue)
            {
                if (townId != 1)
                {
                    var town = _db.Town.FirstOrDefault(t => t.TownID == townId);
                    ViewData["TownName"] = town.TownName;
                    townName = town.TownName;
                }
                else
                {
                    var town = _db.Town.Select(x => x.TownName).Skip(1).ToList();
                    ViewData["TownName"] = town;
                    townName = town.FirstOrDefault();
                }
                //ViewData["TownName"] = townName;

                var townGirls = _db.GirlProfile
                    .Where(girl => girl.TownID == townId)
                    .Select(girl => girl.GirlName)
                    .ToList();
                ViewData["Girls"] = townGirls;

                var girlProfile = _db.GirlProfile
                    .Where(girl => girl.GirlId == girlId)
                    .FirstOrDefault();

                return View(girlProfile);
            }

            return NotFound();
        }

        [HttpGet("/profile/{girlName}/", Name = "ProfileMain")]
        public IActionResult ProfileMain(string girlName, string? townName)
        {
            if (townName == null)
                townName = "home";

            int? girlId = GetGirlIdByNameAndTown(townName, girlName);
            int? townId = GetTownIdByName(townName);

            if (girlId.HasValue && townId.HasValue)
            {
                
                    var town = _db.Town.Select(x => x.TownName).Skip(1).ToList();
                    ViewData["TownName"] = town;
                    townName = town.FirstOrDefault();

                var townGirls = _db.GirlProfile
                    .Where(girl => girl.TownID == townId)
                    .Select(girl => girl.GirlName)
                    .ToList();
                ViewData["Girls"] = townGirls;

                var girlProfile = _db.GirlProfile
                    .Where(girl => girl.GirlId == girlId)
                    .FirstOrDefault();

                return View("Profile", girlProfile);
            }

            return NotFound();
        }

        private int? GetGirlIdByNameAndTown(string townName, string girlName)
        {
            var girlProfile = _db.GirlProfile
                .FirstOrDefault(g => g.GirlName == girlName && g.Town.TownUrl == townName);

            return girlProfile?.GirlId;
        }

        private int? GetTownIdByName(string townName)
        {
            var town = _db.Town.FirstOrDefault(t => t.TownUrl == townName);
            ViewData["TownUrl"] = town.TownUrl; // Pass UrlName to the view
            ViewData["PhoneCall"] = town.PhoneNumberCall;
            ViewData["PhoneShow"] = town.PhoneNumberStr;


            return town?.TownID;
        }

    }
}
