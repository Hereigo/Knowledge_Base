using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Net;
using System.Web.Mvc;
using Payments_Net462.Models;

namespace Payments_Net462.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        private readonly PaymentsContext db = new PaymentsContext();

        // TODO:
        // USE THIS !!!

        // TEST LINQ DYMANIC (using System.Linq.Dynamic.Core) :

        public ActionResult USE_THIS()
        {
            IQueryable<Payment> query = db.Payments.Include(p => p.Category);

            // query = query.Where(p => p.CatogoryId == 1 || p.CatogoryId == 2 || p.CatogoryId == 3);
            // by Linq/Dynamic :
            int[] categories = { 1 };

            string selectedCategories = $"CatogoryId={categories[0]}";
            for (int i = 0; i < categories.Length; i++)
                selectedCategories += $" || CatogoryId={categories[i]}";

            query = query.Where(selectedCategories);

            return null; // View(query.ToList());
        }


        // GET: Payments
        public ActionResult Index(int id = 1)
        {
            const int categiryBMO = 43;

            PaymentsWithStatVm result = new PaymentsWithStatVm();

            DateTime minDate = DateTime.Now.AddDays((-1) * id);

            IQueryable<Payment> payments = db.Payments.Include(p => p.Category);

            // TODO:
            // MAKE ME STORED IN DB !!!
            // MAKE ME STORED IN DB !!!
            // MAKE ME STORED IN DB !!!
            ViewBag.alfa = payments.Where(p => p.CatogoryId == 2).Sum(p => p.Amount);
            ViewBag.prima = payments.Where(p => p.CatogoryId == 3).Sum(p => p.Amount);

            if (payments.Any(p => p.CatogoryId == categiryBMO))
            {
                ViewBag.mono = (int)payments.Where(p => p.CatogoryId == categiryBMO).Sum(p => p.Amount);
            }

            int csh = payments.Where(p => p.CatogoryId == 1).Sum(p => p.Amount);
            int nonCsh = payments.Where(p => p.CatogoryId != 1).Sum(p => p.Amount);

            ViewBag.rest = (csh - nonCsh);

            result.PaymentsVm = payments.Where(p => p.PayDate > minDate).OrderByDescending(p => p.PayDate).ToList();

            result.StatistixVm = GetStats();

            return View(result);
        }

        private List<StatistixView> GetStats()
        {
            DateTime today = DateTime.Now;
            DateTime startThisMonth = new DateTime(today.Year, today.Month, 1).AddMinutes(-1); // 23:59 of Previous Day.
            DateTime startPrevMonth = new DateTime(today.Year, today.AddMonths(-1).Month, 1).AddMinutes(-1);
            DateTime startBeforePrevM = new DateTime(today.Year, today.AddMonths(-2).Month, 1).AddMinutes(-1);
            DateTime startBeforeBefPrevM = new DateTime(today.Year, today.AddMonths(-3).Month, 1).AddMinutes(-1);
            DateTime yearAgo = new DateTime(today.AddYears(-1).Year, today.Month, 1).AddMinutes(-1);

            var categories = new List<KeyValuePair<int, string>>()
            {
                // new KeyValuePair<int, string>(16,"ENJ"),
                new KeyValuePair<int, string>(08,"KID"),
                new KeyValuePair<int, string>(11,"FOO"),
                new KeyValuePair<int, string>(45,"HOL"),
                new KeyValuePair<int, string>(07,"HOM"),
                new KeyValuePair<int, string>(10,"QVN"),
            };

            List<StatistixView> stats = new List<StatistixView>();

            foreach (KeyValuePair<int, string> categItem in categories)
            {
                stats.Add(GetStatsRecord(categItem, yearAgo, startBeforeBefPrevM, startBeforePrevM, startPrevMonth, startThisMonth));
            }

            return stats;
        }

        private StatistixView GetStatsRecord(KeyValuePair<int, string> category, DateTime yearAgo, DateTime startBeforeBefPrevM, DateTime startBeforePrevM, DateTime startPrevMonth, DateTime startThisMonth)
        {
            int currMonthSum = db.Payments.Where(p => p.Category.ID == category.Key && p.PayDate > startThisMonth)
                .Select(p => p.Amount).ToList().Sum();
            int prevMonthSum = db.Payments.Where(p => p.Category.ID == category.Key && p.PayDate > startPrevMonth && p.PayDate < startThisMonth)
                .Select(p => p.Amount).ToList().Sum();
            int b4PrevMonSum = db.Payments.Where(p => p.Category.ID == category.Key && p.PayDate > startBeforePrevM && p.PayDate < startPrevMonth)
                .Select(p => p.Amount).ToList().Sum();
            int b4b4PrevMonSum = db.Payments.Where(p => p.Category.ID == category.Key && p.PayDate > startBeforeBefPrevM && p.PayDate < startPrevMonth)
                .Select(p => p.Amount).ToList().Sum();
            int prevYearSum = db.Payments.Where(p => p.Category.ID == category.Key && p.PayDate > yearAgo && p.PayDate < startThisMonth)
                .Select(p => p.Amount).ToList().Sum();

            // exclusion for the single 8680 study payment of the end of 2019 :
            bool kidExclusion = category.Key == 8 && yearAgo < new DateTime(2019, 11, 30);

            return new StatistixView
            {
                CategoryName = category.Value,
                B4PrevMonSummary = b4PrevMonSum,
                B4B4PrevMonSummary = b4b4PrevMonSum,
                CurrentMonth = currMonthSum,
                PreviousMonth = prevMonthSum,
                YearAverage = kidExclusion ? (prevYearSum - 8680) / 12 : prevYearSum / 12,
            };
        }

        // GET: Payments/Create
        public ActionResult Create()
        {
            ViewBag.CatogoryId = new SelectList(db.Categories, "ID", "Name");

            ViewBag.Today = DateTime.Now; //.ToString("MM/dd/yyyy");

            Payment newPay = new Payment { PayDate = DateTime.Today };

            return View(newPay);
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,PayDate,Amount,Description,CatogoryId")] Payment payment, string payFrom)
        {
            if (ModelState.IsValid)
            {
                db.Payments.Add(payment);
                db.SaveChanges();

                if (!string.IsNullOrEmpty(payFrom) && !string.Equals(payFrom, "NONE", StringComparison.OrdinalIgnoreCase))
                {
                    int foundCategId = db.Categories.FirstOrDefault(c => c.Name == payFrom).ID;

                    if (foundCategId != default)
                    {
                        db.Payments.Add(new Payment
                        {
                            Amount = payment.Amount * (-1),
                            CatogoryId = foundCategId,
                            Description = payment.Description,
                            PayDate = payment.PayDate
                        });
                        db.SaveChanges();
                    }
                }

                return RedirectToAction("Index");
            }

            ViewBag.CatogoryId = new SelectList(db.Categories, "ID", "Name", payment.CatogoryId);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            ViewBag.CatogoryId = new SelectList(db.Categories, "ID", "Name", payment.CatogoryId);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,PayDate,Amount,Description,CatogoryId")] Payment payment)
        {
            if (ModelState.IsValid)
            {
                db.Entry(payment).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CatogoryId = new SelectList(db.Categories, "ID", "Name", payment.CatogoryId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Payment payment = db.Payments.Find(id);
            if (payment == null)
            {
                return HttpNotFound();
            }
            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = db.Payments.Find(id);
            db.Payments.Remove(payment);
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
