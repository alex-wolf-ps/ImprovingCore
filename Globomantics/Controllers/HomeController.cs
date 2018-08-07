using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Services;
using Globomantics.Core.Models;
using Globomantics.Constraints;

namespace Globomantics.Controllers
{
    public class HomeController : Controller
    {
        private IRateService rateService;

        public HomeController(IRateService rateService)
        {
            this.rateService = rateService;
        }

        [Route("")]
        [Route("home/index")]
        public IActionResult Index()
        {
            return View();
        }

        [MobileSelector]
        [Route("")]
        [Route("home/index")]
        public IActionResult MobileIndex()
        {
            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
