using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Services;
using Globomantics.Core.Models;

namespace Globomantics.Controllers
{
    public class HomeController : Controller
    {
        private IRateService rateService;

        public HomeController(IRateService rateService)
        {
            this.rateService = rateService;
        }

        public IActionResult Index()
        {
            var homeData = new HomeVM();

            homeData.CDRates = rateService.GetCDRates();
            homeData.CreditCardRates = rateService.GetCreditCardRates();
            homeData.MortgageRates = rateService.GetMortgageRates();

            return View(homeData);
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
