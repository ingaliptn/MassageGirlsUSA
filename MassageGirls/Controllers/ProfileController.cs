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
        public IActionResult Index(int? id, int? TownId)
        {
            //if (TownId != 1)
            //{
            //    var town = _db.Town.FirstOrDefault(t => t.TownID == TownId); 
            //    ViewData["TownName"] = town.TownName;
            //}
            //else
            //{
            //    var town = _db.Town.Select(x => x.TownName).Skip(1).ToList();
            //    ViewData["TownName"] = town;
            //}
            var town = _db.Town.Select(x => x.TownName).Skip(1).ToList();
            ViewData["TownName"] = town;
            var townGirls = _db.GirlProfile.Where(girl => girl.TownID == TownId).Select(girl => girl.GirlName).ToList();
            
            ViewData["Girls"] = townGirls;

            GirlProfile Girls;
            if (id == null)
                Girls = _db.GirlProfile.FirstOrDefault();
            else
                Girls = _db.GirlProfile.Where(x => x.GirlId == id).FirstOrDefault();

            return View(Girls);
        }
    }
}
