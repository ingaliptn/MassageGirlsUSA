using MassageGirls.Context;
using MassageGirls.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MassageGirls.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ServiceController : Controller
    {
        private readonly AppDbContext _db;
        public ServiceController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<GirlProfile> girls = _db.GirlProfile.ToList();
            return View(girls);
        }
        public IActionResult IndexTown()
        {
            IEnumerable<Town> town = _db.Town.ToList();
            return View(town);
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
            return RedirectToAction("Index");
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
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditTown(int id)
        {
            Town town = _db.Town.Find(id);

            if (town == null)
            {
                return NotFound();
            }

            return View(town);
        }

        [HttpPost]
        public IActionResult EditTown(Town town)
        {
            _db.Town.Update(town);
            _db.SaveChanges();
            return RedirectToAction("IndexTown");
        }
    }
}
