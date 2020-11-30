using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using CinoSomMVC.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CinoSomMVC.Models;

namespace CinoSomMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPaymentsContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, IPaymentsContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Test()
        {
            var test = _context.Categories.ToList();

            return View(test);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}