using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Core.Models;
using Microsoft.Extensions.Logging;

namespace Globomantics.Controllers
{
    public class InsuranceController : Controller
    {
        private ILogger<InsuranceController> logger;

        public InsuranceController(ILogger<InsuranceController> logger)
        {
            this.logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Contact contact)
        {
            if (ModelState.IsValid)
            {
                // Todo: Send contact message
                return RedirectToAction("Confirmation");
            }
            else
            {
                logger.LogInformation("Bad model", contact);
                return View(contact);
            }
        }

        public IActionResult Confirmation()
        {
            return View();
        }
    }
}
