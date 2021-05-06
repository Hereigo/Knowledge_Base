using System;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MyXpens.Models;

namespace MyXpens.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly PaymentsContext _dbContext;

        public HomeController(ILogger<HomeController> logger, PaymentsContext dbContext)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public IActionResult Test()
        {
            return Content("202");
        }

        public IActionResult Index(string errorMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.ServerTime = DateTime.Now.ToString("HH:mm:ss");

            var payments = _dbContext.Payments.ToArray();

            ViewBag.mono = payments.Where(p => p.CatogoryId == 43)?.Sum(p => p.Amount) ?? 0;
            int csh = payments.Where(p => p.CatogoryId == 1)?.Sum(p => p.Amount) ?? 0;
            int nonCsh = payments.Where(p => p.CatogoryId != 1)?.Sum(p => p.Amount) ?? 0;
            ViewBag.rest = csh - nonCsh;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}