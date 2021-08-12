using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using MyXpens.Data;
using MyXpens.Models;

namespace MyXpens.Controllers
{
    [Authorize]
    public class PaymentsController : Controller
    {
        private const int timezonesCorrection = 3; // fix by UTC + TimeZone!
        private readonly AppStaticValues _appValues;
        private readonly PaymentsContext _dbContext;

        public PaymentsController(IOptions<AppStaticValues> appValues, PaymentsContext context)
        {
            _dbContext = context;
            _appValues = appValues.Value;
        }

        public ActionResult Index(int id = 1)
        {
            var result = new PaymentsWithStatVm();
            var minDate = DateTime.Now.AddDays((-1) * id);
            var payments = _dbContext.Payments.Include(p => p.Category);

            // TODO:
            // MAKE ME STORED IN DB !!!
            int csh = payments.Where(p => p.CatogoryId == 1)?.Sum(p => p.Amount) ?? 0;
            int nonCsh = payments.Where(p => p.CatogoryId != 1)?.Sum(p => p.Amount) ?? 0;
            ViewBag.alfa = payments.Where(p => p.CatogoryId == 2)?.Sum(p => p.Amount) ?? 0;
            ViewBag.mono = payments.Where(p => p.CatogoryId == 43)?.Sum(p => p.Amount) ?? 0;
            ViewBag.prima = payments.Where(p => p.CatogoryId == 3)?.Sum(p => p.Amount) ?? 0;
            ViewBag.rest = csh - nonCsh;

            result.StatistixVm = GetStats();

            result.PaymentsVm = payments
                .Where(p => p.PayDate > minDate).OrderByDescending(p => p.PayDate).ToList();

            return View(result);
        }

        public ActionResult Create()
        {
            ViewBag.CatogoryId = new SelectList(_dbContext.Categories.Where(c => c.IsActive).OrderBy(c => c.Name), "ID", "Name");

            //ViewBag.Today = DateTime.Now; - ???

            Payment newPay = new() { PayDate = DateTime.Now.AddHours(timezonesCorrection) };

            return View(newPay);
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Payment payment, string payFrom)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home", new { errorMessage = "Invalid Model can't be save!" });
            }
            else
            {
                if (!payFrom.Equals("NONE", StringComparison.OrdinalIgnoreCase))
                {
                    var paymentSourceCatId = _dbContext.Categories?.FirstOrDefault(c => c.Name == payFrom)?.ID ?? 0;

                    if (paymentSourceCatId == 0 || paymentSourceCatId == payment.CatogoryId)
                    {
                        return RedirectToAction("Index", "Home",
                            new { errorMessage = $"Invalid payment Source Category : {payFrom} and can't be save!" });
                    }
                    else
                    {
                        _dbContext.Payments.Add(new Payment
                        {
                            Amount = payment.Amount * (-1),
                            CatogoryId = paymentSourceCatId,
                            Description = payment.Description,
                            PayDate = payment.PayDate == default
                                    ? DateTime.UtcNow.AddHours(timezonesCorrection)
                                    : payment.PayDate.AddHours(timezonesCorrection)
                        });
                        _dbContext.SaveChanges();
                    }
                }

                _dbContext.Payments.Add(payment);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", new { id = 2 });
            }
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Payment payment = _dbContext.Payments.Find(id);
            if (payment == null)
            {
                return NotFound();
            }

            ViewBag.CatogoryId =
                new SelectList(_dbContext.Categories.Where(c => c.IsActive).OrderBy(c => c.Name), "ID", "Name", payment.CatogoryId);

            return View(payment);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Payment payment)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Entry(payment).State = EntityState.Modified;
                _dbContext.SaveChanges();

                return RedirectToAction("Index", new { id = 2 });
            }

            ViewBag.CatogoryId =
                new SelectList(_dbContext.Categories.Where(c => c.IsActive).OrderBy(c => c.Name), "ID", "Name", payment.CatogoryId);

            return View(payment);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Payment payment = _dbContext.Payments.Find(id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = _dbContext.Payments.Find(id);
            _dbContext.Payments.Remove(payment);
            _dbContext.SaveChanges();

            return RedirectToAction("Index", new { id = 2 });
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }

            base.Dispose(disposing);
        }

        private List<StatistixView> GetStats()
        {
            var stats = new List<StatistixView>();

            var today = DateTime.Now;
            var startThisMonth = new DateTime(today.Year, today.Month, 1).AddMinutes(-1); // 23:59 of Previous Day.
            var startPrevMonth = new DateTime(today.Year, today.AddMonths(-1).Month, 1).AddMinutes(-1);
            var startBeforePrevM = new DateTime(today.Year, today.AddMonths(-2).Month, 1).AddMinutes(-1);
            var startBeforeBefPrevM = new DateTime(today.Year, today.AddMonths(-3).Month, 1).AddMinutes(-1);
            var yearAgo = new DateTime(today.AddYears(-1).Year, today.Month, 1).AddMinutes(-1);

            var categories = new List<KeyValuePair<int, string>>()
            {
                new KeyValuePair<int, string>(07, "HOM"),
                new KeyValuePair<int, string>(08, "KID"),
                new KeyValuePair<int, string>(09, "KIU"),
                new KeyValuePair<int, string>(10, "QVN"),
                // new KeyValuePair<int, string>(11, "FOO"), //
                new KeyValuePair<int, string>(13, "HLS"),
                // new KeyValuePair<int, string>(16,"ENJ"), //
                new KeyValuePair<int, string>(18, "VLG"),
                new KeyValuePair<int, string>(19, "KSH"),
                new KeyValuePair<int, string>(4, "CEX"),
                // new KeyValuePair<int, string>(43,"BMO"), //
                new KeyValuePair<int, string>(45, "HOL"),
                // new KeyValuePair<int, string>(48, "SCH"), //
            };

            foreach (KeyValuePair<int, string> categItem in categories)
            {
                stats.Add(GetStatsRecord(categItem, yearAgo, startBeforeBefPrevM, startBeforePrevM, startPrevMonth,
                    startThisMonth));
            }

            return stats;
        }

        public async Task<IActionResult> GetTestData()
        {
            var test = new MbClient(_appValues);
            var rezult = await test
                .GetTestData(
                _dbContext.Categories.FirstOrDefault(c => c.ID.Equals(50)).Name + Converter.TestString)
                .ConfigureAwait(false);

            return Ok(rezult);
        }

        private StatistixView GetStatsRecord(KeyValuePair<int, string> category, DateTime yearAgo,
            DateTime startBeforeBefPrevM, DateTime startBeforePrevM, DateTime startPrevMonth, DateTime startThisMonth)
        {
            int currMonthSum = _dbContext.Payments
                .Where(p => p.Category.ID == category.Key && p.PayDate > startThisMonth)
                .Select(p => p.Amount).Sum();
            int prevMonthSum = _dbContext.Payments.Where(p =>
                    p.Category.ID == category.Key && p.PayDate > startPrevMonth && p.PayDate < startThisMonth)
                .Select(p => p.Amount).Sum();
            int b4PrevMonSum = _dbContext.Payments.Where(p =>
                    p.Category.ID == category.Key && p.PayDate > startBeforePrevM && p.PayDate < startPrevMonth)
                .Select(p => p.Amount).Sum();
            int b4b4PrevMonSum = _dbContext.Payments.Where(p =>
                    p.Category.ID == category.Key && p.PayDate > startBeforeBefPrevM && p.PayDate < startPrevMonth)
                .Select(p => p.Amount).Sum();
            int prevYearSum = _dbContext.Payments.Where(p =>
                    p.Category.ID == category.Key && p.PayDate > yearAgo && p.PayDate < startThisMonth)
                .Select(p => p.Amount).Sum();

            ViewBag.CurrMonth = DateTime.Now.Month;

            return new StatistixView
            {
                B4B4PrevMonSummary = SimplifyNumberForView(b4b4PrevMonSum),
                B4PrevMonSummary = SimplifyNumberForView(b4PrevMonSum),
                CategoryName = category.Value,
                CurrentMonth = SimplifyNumberForView(currMonthSum),
                PreviousMonth = SimplifyNumberForView(prevMonthSum),
                YearAverage = SimplifyNumberForView(prevYearSum / 12)
            };
        }

        private static string SimplifyNumberForView(int decimalNumber)
        {
            return
               string.Format("{0:G29}",
                    Math.Round(Convert.ToDecimal(decimalNumber) / 1000, 1));
        }
    }
}