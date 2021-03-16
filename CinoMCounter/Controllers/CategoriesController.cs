using System.Linq;
using CinoMCounter.Data;
using CinoMCounter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CinoMCounter.Controllers
{
        
    // TEMPORARY !!!!!!!!!!!
    
    // [Authorize]
    
    
    public class CategoriesController: Controller
    {
        private readonly PaymentsContext db;
        private readonly ILogger<HomeController> _logger;

        public CategoriesController(ILogger<HomeController> logger, PaymentsContext context)
        {
            _logger = logger;
            db = context;
        }
        
        public ActionResult Index()
        {
            var test = db.Categories.ToList();
            
            return View(test);
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category) //[Bind(Include = "ID,Name,IsActive")] Category category)
        {
            if (ModelState.IsValid)
            {
                db.Categories.Add(category);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: Categories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category) // [Bind(Include = "ID,Name,IsActive")] Category category)
        {
            if (ModelState.IsValid)
            {
                // .Net 4.8 :
                // db.Entry(category).State = EntityState.Modified;
                
                var existedCategory = db.Categories.Single(c => c.ID == category.ID);
                db.Entry(existedCategory).CurrentValues.SetValues(category);
                db.SaveChanges();
                
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: Categories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category); 
            db.SaveChanges();
            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
