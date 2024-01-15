using MassageGirls.Context;
using MassageGirls.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MassageGirls.Controllers
{
    public class AdminController : Controller
    {
        private readonly AppDbContext _db;
        public AdminController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<GirlProfile> girls = _db.GirlProfile.ToList();
            return View(girls);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.MassageTypes = new SelectList(_db.MassageType, "MassageTypeID", "TypeName");
            ViewBag.Towns = new SelectList(_db.Town, "TownID", "TownName");
            return View();
        }

        [HttpPost]
        public IActionResult Create(GirlProfile profile)
        {
            _db.GirlProfile.Add(profile);
            _db.SaveChanges();
            return RedirectToAction("Create");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            GirlProfile girlProfile = _db.GirlProfile.Find(id);

            if (girlProfile == null)
            {
                return NotFound();
            }

            ViewBag.MassageTypes = new SelectList(_db.MassageType, "MassageTypeID", "TypeName");
            ViewBag.Towns = new SelectList(_db.Town, "TownID", "TownName");

            return View(girlProfile);
        }

        [HttpPost]
        public IActionResult Edit(GirlProfile girlProfile)
        {
            _db.GirlProfile.Update(girlProfile);
            _db.SaveChanges();
            return RedirectToAction("Edit");
        }
    }
}
