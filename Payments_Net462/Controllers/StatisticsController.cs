using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Web.Mvc;
using Payments_Net462.Models;

namespace Payments_Net462.Controllers
{
    [Authorize]
    public class StatisticsController : Controller
    {
        private readonly PaymentsContext db = new PaymentsContext();

        public ActionResult Index()
        {
            DateTime halfYearAgo = DateTime.Now.AddMonths(-6);
            DateTime startThisMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            DateTime sixMonthAgo = new DateTime(halfYearAgo.Year, halfYearAgo.Month, 1);

            int HomCatId = 7;
            int KidCatId = 8;
            int EnjCatId = 16;

            int homThisMonth = db.Payments.Where(p => p.Category.ID == HomCatId && p.PayDate > startThisMonth).Select(p => p.Amount).ToList().Sum();
            int kidThisMonth = db.Payments.Where(p => p.Category.ID == KidCatId && p.PayDate > startThisMonth).Select(p => p.Amount).ToList().Sum();
            int enjThisMonth = db.Payments.Where(p => p.Category.ID == EnjCatId && p.PayDate > startThisMonth).Select(p => p.Amount).ToList().Sum();

            int homHalfYear = db.Payments.Where(p => p.Category.ID == HomCatId && p.PayDate > sixMonthAgo).Select(p => p.Amount).ToList().Sum();
            int kidHalfYear = db.Payments.Where(p => p.Category.ID == KidCatId && p.PayDate > sixMonthAgo).Select(p => p.Amount).ToList().Sum();
            int enjHalfYear = db.Payments.Where(p => p.Category.ID == EnjCatId && p.PayDate > sixMonthAgo).Select(p => p.Amount).ToList().Sum();


            List<Payment> list = new List<Payment>()
            {
                new Payment { PayDate = startThisMonth, Amount = homThisMonth, Description = "HOM: " + DateTime.Now.ToString("MMMMM")},
                new Payment { PayDate = sixMonthAgo, Amount = (homHalfYear - homThisMonth) / 6, Description = "HOM: last 6 m." },

                new Payment { PayDate = startThisMonth, Amount = kidThisMonth, Description = "KID: " + DateTime.Now.ToString("MMMMM")},
                new Payment { PayDate = sixMonthAgo, Amount = (kidHalfYear - kidThisMonth) / 6, Description = "KID: last 6 m." },

                new Payment { PayDate = startThisMonth, Amount = enjThisMonth, Description = "ENJ: " + DateTime.Now.ToString("MMMMM")},
                new Payment { PayDate = sixMonthAgo, Amount = (enjHalfYear - enjThisMonth) / 6, Description = "ENJ: last 6 m." },
            };

            return View(list);
        }

        // TEST LINQ DYMANIC (using System.Linq.Dynamic.Core) :
        public ActionResult Test()
        {
            IQueryable<Payment> query = db.Payments.Include(p => p.Category);

            // query = query.Where(p => p.CatogoryId == 1 || p.CatogoryId == 2 || p.CatogoryId == 3);
            // by Linq/Dynamic :
            int[] categories = { 1 };

            string selectedCategories = $"CatogoryId={categories[0]}";

            for (int i = 0; i < categories.Length; i++)
                selectedCategories += $" || CatogoryId={categories[i]}";

            query = query.Where(selectedCategories);

            return View(query.ToList());
        }



        //            DateTime startDate = new DateTime(2018, 6, 15);

        //            // IQueryable<Payment> 
        //            //var payments = db.Payments
        //            //	.Where(p => p.PayDate >= startDate)
        //            //	.GroupBy(p => p.PayDate.Month)
        //            //	.Select(p => p.)

        //            return RedirectToAction("");
        //        }

        //        // GET: Payments
        //        public ActionResult Index_OLD(int id = 2)
        //        {
        //#if DEBUG
        //            const int categiryBMO = 20;  // local db
        //#else
        //			const int categiryBMO = 43;  // remote db
        //#endif
        //            DateTime minDate = DateTime.Now.AddDays((-1) * id);
        //            IQueryable<Payment> payments = db.Payments.Include(p => p.Category);

        //            // TODO:
        //            // make me stored in db !!!
        //            // make me stored in db !!!
        //            // make me stored in db !!!
        //            ViewBag.alfa = payments.Where(p => p.CatogoryId == 2).Sum(p => p.Amount);
        //            ViewBag.prima = payments.Where(p => p.CatogoryId == 3).Sum(p => p.Amount);

        //            if (payments.Any(p => p.CatogoryId == categiryBMO))
        //            {
        //                int monoRez = payments.Where(p => p.CatogoryId == categiryBMO).Sum(p => p.Amount);

        //                ViewBag.mono = monoRez;
        //                ViewBag.mono2 = monoRez + 12500;
        //            }

        //            int csh = payments.Where(p => p.CatogoryId == 1).Sum(p => p.Amount);
        //            int nonCsh = payments.Where(p => p.CatogoryId != 1).Sum(p => p.Amount);

        //            ViewBag.rest = (csh - nonCsh);

        //            return null; // View(payments.Where(p => p.PayDate > minDate).OrderByDescending(p => p.PayDate).ToList());
        //        }

        //        // GET: Payments/Details/5
        //        public ActionResult Details(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            Payment payment = db.Payments.Find(id);
        //            if (payment == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return null; //  View(payment);
        //        }

        //        // GET: Payments/Create
        //        public ActionResult Create()
        //        {
        //            ViewBag.CatogoryId = new SelectList(db.Categories, "ID", "Name");

        //            ViewBag.Today = DateTime.Now; //.ToString("MM/dd/yyyy");

        //            Payment newPay = new Payment { PayDate = DateTime.Today };

        //            return null; //  View(newPay);
        //        }

        //        // POST: Payments/Create
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Create([Bind(Include = "ID,PayDate,Amount,Description,CatogoryId")] Payment payment)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.Payments.Add(payment);
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }

        //            ViewBag.CatogoryId = new SelectList(db.Categories, "ID", "Name", payment.CatogoryId);
        //            return null; //  View(payment);
        //        }

        //        // GET: Payments/Edit/5
        //        public ActionResult Edit(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            Payment payment = db.Payments.Find(id);
        //            if (payment == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            ViewBag.CatogoryId = new SelectList(db.Categories, "ID", "Name", payment.CatogoryId);
        //            return null; //  View(payment);
        //        }

        //        // POST: Payments/Edit/5
        //        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //        [HttpPost]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult Edit([Bind(Include = "ID,PayDate,Amount,Description,CatogoryId")] Payment payment)
        //        {
        //            if (ModelState.IsValid)
        //            {
        //                db.Entry(payment).State = EntityState.Modified;
        //                db.SaveChanges();
        //                return RedirectToAction("Index");
        //            }
        //            ViewBag.CatogoryId = new SelectList(db.Categories, "ID", "Name", payment.CatogoryId);
        //            return null; //  View(payment);
        //        }

        //        // GET: Payments/Delete/5
        //        public ActionResult Delete(int? id)
        //        {
        //            if (id == null)
        //            {
        //                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //            }
        //            Payment payment = db.Payments.Find(id);
        //            if (payment == null)
        //            {
        //                return HttpNotFound();
        //            }
        //            return null; //  View(payment);
        //        }

        //        // POST: Payments/Delete/5
        //        [HttpPost, ActionName("Delete")]
        //        [ValidateAntiForgeryToken]
        //        public ActionResult DeleteConfirmed(int id)
        //        {
        //            Payment payment = db.Payments.Find(id);
        //            db.Payments.Remove(payment);
        //            db.SaveChanges();
        //            return RedirectToAction("Index");
        //        }

        //        protected override void Dispose(bool disposing)
        //        {
        //            if (disposing)
        //            {
        //                db.Dispose();
        //            }
        //            base.Dispose(disposing);
        //        }
    }
}
