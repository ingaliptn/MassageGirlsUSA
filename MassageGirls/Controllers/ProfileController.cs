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
        public IActionResult Index(int? id)
        {
            GirlProfile Girls;
            if (id == null)
                Girls = _db.GirlProfile.FirstOrDefault();
            else
                Girls = _db.GirlProfile.Where(x => x.GirlId == id).FirstOrDefault();

            return View(Girls);
        }
    }
}
