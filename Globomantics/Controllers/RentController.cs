using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Services;
using Microsoft.Extensions.Logging;

namespace Globomantics.Controllers
{
    public class RentController : Controller
    {
        private ILogger<RentController> logger;
        private IQuoteService quoteService;

        public RentController(IQuoteService quoteService, ILogger<RentController> logger)
        {
            this.logger = logger;
            this.quoteService = quoteService;
        }

        public IActionResult Quote()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Quote(RentalQuote quote)
        {
            if (ModelState.IsValid)
            {
                quoteService.GenerateRentalQuote(quote);
                return RedirectToAction("Insurance", "Confirmation");
            }
            else
            {
                logger.LogInformation("Bad model", quote);
                return View(quote);
            }
        }
    }
}
