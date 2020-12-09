﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CinoMCounter.Data;
using CinoMCounter.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace CinoMCounter.Controllers
{
    // TEMPORARY !!!!!!!!!!!

    // [Authorize]

    public class PaymentsController : Controller
    {
        const string backupMarker = "shouldCreateBkp";

        private readonly IPaymentsContext _db;
        private readonly ILogger<HomeController> _logger;
        public IWebHostEnvironment _env { get; set; }

        public PaymentsController(ILogger<HomeController> logger, IPaymentsContext context, IWebHostEnvironment env)
        {
            _logger = logger;
            _db = context;
            _env = env;
        }

        // GET: Payments
        public ActionResult Index(int id = 1)
        {
            // When Redirect from Create-Action :
            if (bool.TryParse(TempData[backupMarker]?.ToString(), out bool isNewCreated) && isNewCreated)
            {
                // TODO:
                // MAKE ME ASYNC !!!

                // TODO:
                // USE DI !!!!!!!!!

                DatabaseManager dbMgr = new DatabaseManager(_db, _env);
                ViewBag.BackUpResult = dbMgr.CreateBackUp();
            }

            const int categoryBmo = 43;

            var result = new PaymentsWithStatVm();

            var minDate = DateTime.Now.AddDays((-1) * id);

            var payments = _db.Payments.Include(p => p.Category);

            // TODO:
            // MAKE ME STORED IN DB !!!
            // MAKE ME STORED IN DB !!!
            // MAKE ME STORED IN DB !!!
            ViewBag.alfa = payments.Where(p => p.CatogoryId == 2).Sum(p => p.Amount);
            ViewBag.prima = payments.Where(p => p.CatogoryId == 3).Sum(p => p.Amount);

            if (payments.Any(p => p.CatogoryId == categoryBmo))
            {
                ViewBag.mono = (int) payments.Where(p => p.CatogoryId == categoryBmo).Sum(p => p.Amount);
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

        private StatistixView GetStatsRecord(KeyValuePair<int, string> category, DateTime yearAgo,
            DateTime startBeforeBefPrevM, DateTime startBeforePrevM, DateTime startPrevMonth, DateTime startThisMonth)
        {
            int currMonthSum = _db.Payments.Where(p => p.Category.ID == category.Key && p.PayDate > startThisMonth)
                .Select(p => p.Amount).ToList().Sum();
            int prevMonthSum = _db.Payments.Where(p =>
                    p.Category.ID == category.Key && p.PayDate > startPrevMonth && p.PayDate < startThisMonth)
                .Select(p => p.Amount).ToList().Sum();
            int b4PrevMonSum = _db.Payments.Where(p =>
                    p.Category.ID == category.Key && p.PayDate > startBeforePrevM && p.PayDate < startPrevMonth)
                .Select(p => p.Amount).ToList().Sum();
            int b4b4PrevMonSum = _db.Payments.Where(p =>
                    p.Category.ID == category.Key && p.PayDate > startBeforeBefPrevM && p.PayDate < startPrevMonth)
                .Select(p => p.Amount).ToList().Sum();
            int prevYearSum = _db.Payments.Where(p =>
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

        // GET: Payments/Create
        public ActionResult Create()
        {
            ViewBag.CatogoryId = new SelectList(_db.Categories.OrderBy(c => c.Name), "ID", "Name");

            ViewBag.Today = DateTime.Now; //.ToString("MM/dd/yyyy");

            Payment newPay = new Payment {PayDate = DateTime.Today};

            return View(newPay);
        }

        // POST: Payments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( // [Bind(Include = "ID,PayDate,Amount,Description,CatogoryId")]
            Payment payment, string payFrom)
        {
            if (ModelState.IsValid)
            {
                _db.Payments.Add(payment);
                // _db.SaveChanges();

                // Create Source Decreasing payment according the previous one:

                if (!string.IsNullOrEmpty(payFrom)
                    && !string.Equals(payFrom, "NONE", StringComparison.OrdinalIgnoreCase))
                {
                    int categoryIdToFind = _db.Categories?.FirstOrDefault(c => c.Name == payFrom)?.ID ?? 0;

                    if (categoryIdToFind != default)
                    {
                        _db.Payments.Add(new Payment
                        {
                            Amount = payment.Amount * (-1),
                            CatogoryId = categoryIdToFind,
                            Description = payment.Description,
                            PayDate = payment.PayDate
                        });
                        // _db.SaveChanges();
                    }
                }

                TempData[backupMarker] = true;

                return RedirectToAction("Index", new {id = 2});
            }

            ViewBag.CatogoryId = new SelectList(_db.Categories.OrderBy(c => c.Name), "ID", "Name", payment.CatogoryId);
            return View(payment);
        }

        // GET: Payments/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Payment payment = _db.Payments.Find(id);
            if (payment == null)
            {
                return NotFound();
            }

            ViewBag.CatogoryId = new SelectList(_db.Categories.OrderBy(c => c.Name), "ID", "Name", payment.CatogoryId);
            return View(payment);
        }

        // POST: Payments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( // [Bind(Include = "ID,PayDate,Amount,Description,CatogoryId")]
            Payment payment)
        {
            if (ModelState.IsValid)
            {
                // _db.Entry(payment).State = EntityState.Modified;
                // _db.SaveChanges();

                TempData[backupMarker] = true;

                return RedirectToAction("Index", new {id = 2});
            }

            ViewBag.CatogoryId = new SelectList(_db.Categories.OrderBy(c => c.Name), "ID", "Name", payment.CatogoryId);
            return View(payment);
        }

        // GET: Payments/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return BadRequest();
            }

            Payment payment = _db.Payments.Find(id);
            if (payment == null)
            {
                return NotFound();
            }

            return View(payment);
        }

        // POST: Payments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Payment payment = _db.Payments.Find(id);
            _db.Payments.Remove(payment);
            // _db.SaveChanges();
            return RedirectToAction("Index", new {id = 2});
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                // _db.Dispose();
            }

            base.Dispose(disposing);
        }
    }
}