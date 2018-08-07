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
    public class PropertyController : Controller
    {
        private ILogger<PropertyController> logger;
        private IQuoteService quoteService;

        public PropertyController(IQuoteService quoteService, ILogger<PropertyController> logger)
        {
            this.logger = logger;
            this.quoteService = quoteService;
        }

        public IActionResult Quote()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Quote(PropertyQuote quote)
        {
            if (ModelState.IsValid)
            {
                quoteService.GeneratePropertyQuote(quote);
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
