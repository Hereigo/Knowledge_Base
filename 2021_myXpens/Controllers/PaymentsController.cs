using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Text;
using System.Text.Json;
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
        private readonly AppStaticValues _appValues;
        private readonly PaymentsContext _dbContext;

        public PaymentsController(IOptions<AppStaticValues> appValues, PaymentsContext context)
        {
            _dbContext = context;
            _appValues = appValues.Value;
        }

        public ActionResult GetBkpJson()
        {
            var bkp = _dbContext.Payments
                .Include(p => p.Category)
                .OrderByDescending(p => p.PayDate).ToArray();

            var json = JsonSerializer.Serialize(bkp);

            // A: Simple JSON response:
            // return Content(json, "application/json");

            // B: ZIPPED json response:
            return File(ZipString(json), "application/octet-stream", $"{DateTime.Now:yy.MM.dd}_xPens_BKP.zip");

            // C: If needed to response a raw JSON FILE:
            var stream = new MemoryStream();
            var sw = new StreamWriter(stream);
            sw.Write(json);
            sw.Flush();
            stream.Position = 0;

            return File(stream, "application/octet-stream");
        }

        public ActionResult Index(int id = 1)
        {
            var result = new PaymentsWithStatVm();

            var minDate = DateTime.Now.AddDays((-1) * id);

            var payments = _dbContext.Payments.Include(p => p.Category);

            // TODO:
            // MAKE ME STORED IN DB !!!
            // MAKE ME STORED IN DB !!!
            // MAKE ME STORED IN DB !!!
            ViewBag.alfa = payments.Where(p => p.CatogoryId == 2)?.Sum(p => p.Amount) ?? 0;
            ViewBag.prima = payments.Where(p => p.CatogoryId == 3)?.Sum(p => p.Amount) ?? 0;
            ViewBag.mono = payments.Where(p => p.CatogoryId == 43)?.Sum(p => p.Amount) ?? 0;

            int csh = payments.Where(p => p.CatogoryId == 1)?.Sum(p => p.Amount) ?? 0;
            int nonCsh = payments.Where(p => p.CatogoryId != 1)?.Sum(p => p.Amount) ?? 0;

            ViewBag.rest = csh - nonCsh;

            ViewBag.test = GetTestData();

            result.PaymentsVm = payments
                .Where(p => p.PayDate > minDate).OrderByDescending(p => p.PayDate).ToList();

            result.StatistixVm = GetStats();

            return View(result);
        }

        public ActionResult Create()
        {
            ViewBag.CatogoryId = new SelectList(_dbContext.Categories.OrderBy(c => c.Name), "ID", "Name");
            ViewBag.Today = DateTime.Now;
            Payment newPay = new Payment { PayDate = DateTime.Now.AddHours(10) }; // fix by UTC + TimeZone!

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
                            PayDate = payment.PayDate
                        });
                        _dbContext.SaveChanges();
                    }
                }

                _dbContext.Payments.Add(payment);
                _dbContext.SaveChanges();

                return RedirectToAction("Index", new { id = 2 });
            }

            ViewBag.CatogoryId =
                new SelectList(_dbContext.Categories.OrderBy(c => c.Name), "ID", "Name", payment.CatogoryId);

            return View(payment);
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
                new SelectList(_dbContext.Categories.OrderBy(c => c.Name), "ID", "Name", payment.CatogoryId);
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
                new SelectList(_dbContext.Categories.OrderBy(c => c.Name), "ID", "Name", payment.CatogoryId);
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

        private static byte[] ZipString(string str)
        {
            var bytes = Encoding.UTF8.GetBytes(str);

            using (var msi = new MemoryStream(bytes))
            using (var mso = new MemoryStream())
            {
                using (var gs = new GZipStream(mso, CompressionMode.Compress))
                {
                    byte[] bytesBuffer = new byte[4096];
                    int cnt;
                    while ((cnt = msi.Read(bytesBuffer, 0, bytesBuffer.Length)) != 0)
                    {
                        gs.Write(bytesBuffer, 0, cnt);
                    }
                }
                return mso.ToArray();
            }
        }

        private List<StatistixView> GetStats()
        {
            var today = DateTime.Now;
            var startThisMonth = new DateTime(today.Year, today.Month, 1).AddMinutes(-1); // 23:59 of Previous Day.
            var startPrevMonth = new DateTime(today.Year, today.AddMonths(-1).Month, 1).AddMinutes(-1);
            var startBeforePrevM = new DateTime(today.Year, today.AddMonths(-2).Month, 1).AddMinutes(-1);
            var startBeforeBefPrevM = new DateTime(today.Year, today.AddMonths(-3).Month, 1).AddMinutes(-1);
            var yearAgo = new DateTime(today.AddYears(-1).Year, today.Month, 1).AddMinutes(-1);

            var categories = new List<KeyValuePair<int, string>>()
            {
                // new KeyValuePair<int, string>(16,"ENJ"),
                // new KeyValuePair<int, string>(43,"BMO"),
                new KeyValuePair<int, string>(18, "VLG"),
                new KeyValuePair<int, string>(19, "KSH"),
                new KeyValuePair<int, string>(13, "HLS"),
                new KeyValuePair<int, string>(09, "KIU"),
                new KeyValuePair<int, string>(08, "KID"),
                new KeyValuePair<int, string>(11, "FOO"),
                new KeyValuePair<int, string>(45, "HOL"),
                new KeyValuePair<int, string>(07, "HOM"),
                new KeyValuePair<int, string>(10, "QVN"),
                new KeyValuePair<int, string>(48, "SCH"),
            };

            var stats = new List<StatistixView>();

            foreach (KeyValuePair<int, string> categItem in categories)
            {
                stats.Add(GetStatsRecord(categItem, yearAgo, startBeforeBefPrevM, startBeforePrevM, startPrevMonth,
                    startThisMonth));
            }

            return stats;
        }

        private async Task<string> GetTestData()
        {
            var test = new MbClient(_appValues);
            return await test
                .GetTestData(
                _dbContext.Categories.FirstOrDefault(c => c.ID.Equals(50)).Name + Converter.TestString);
        }

        private StatistixView GetStatsRecord(KeyValuePair<int, string> category, DateTime yearAgo,
            DateTime startBeforeBefPrevM, DateTime startBeforePrevM, DateTime startPrevMonth, DateTime startThisMonth)
        {
            int currMonthSum = _dbContext.Payments
                .Where(p => p.Category.ID == category.Key && p.PayDate > startThisMonth)
                .Select(p => p.Amount).ToList().Sum();
            int prevMonthSum = _dbContext.Payments.Where(p =>
                    p.Category.ID == category.Key && p.PayDate > startPrevMonth && p.PayDate < startThisMonth)
                .Select(p => p.Amount).ToList().Sum();
            int b4PrevMonSum = _dbContext.Payments.Where(p =>
                    p.Category.ID == category.Key && p.PayDate > startBeforePrevM && p.PayDate < startPrevMonth)
                .Select(p => p.Amount).ToList().Sum();
            int b4b4PrevMonSum = _dbContext.Payments.Where(p =>
                    p.Category.ID == category.Key && p.PayDate > startBeforeBefPrevM && p.PayDate < startPrevMonth)
                .Select(p => p.Amount).ToList().Sum();
            int prevYearSum = _dbContext.Payments.Where(p =>
                    p.Category.ID == category.Key && p.PayDate > yearAgo && p.PayDate < startThisMonth)
                .Select(p => p.Amount).ToList().Sum();

            ViewBag.CurrMonth = DateTime.Now.Month;

            return new StatistixView
            {
                CategoryName = category.Value,
                B4PrevMonSummary = b4PrevMonSum,
                B4B4PrevMonSummary = b4b4PrevMonSum,
                CurrentMonth = currMonthSum,
                PreviousMonth = prevMonthSum,
                YearAverage = prevYearSum / 12,
            };
        }
    }
}