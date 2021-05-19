using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyXpens.Models;

namespace MyXpens.Controllers
{
    [Authorize]
    public class CategoriesController : Controller
    {
        private readonly DbContextOptions<PaymentsContext> _options;
        private readonly PaymentsContext _dbContext;

        public CategoriesController(DbContextOptions<PaymentsContext> options, PaymentsContext dbContext)
        {
            _options = options;
            _dbContext = dbContext;
        }

        // GET: Categories
        public ActionResult Index()
        {
            return View(_dbContext.Categories.ToList());
        }

        // GET: Categories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }
            Category category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // GET: Categories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categories/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Category category) //[Bind(Include = "ID,Name,IsActive")] Category category)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Categories.Add(category);
                _dbContext.SaveChanges();
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
            Category category = _dbContext.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        // POST: Categories/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category category) // [Bind(Include = "ID,Name,IsActive")] Category category)
        {
            if (ModelState.IsValid)
            {
                // .Net 4.8 :
                // db.Entry(category).State = EntityState.Modified;
                var existedCategory = _dbContext.Categories.Single(c => c.ID == category.ID);
                _dbContext.Entry(existedCategory).CurrentValues.SetValues(category);
                _dbContext.SaveChanges();
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
            Category category = _dbContext.Categories.Find(id);
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
            Category category = _dbContext.Categories.Find(id);
            _dbContext.Categories.Remove(category);
            _dbContext.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
