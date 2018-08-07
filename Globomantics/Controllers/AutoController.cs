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
    public class AutoController : Controller
    {
        private ILogger<AutoController> logger;
        private IQuoteService quoteService;

        public AutoController(IQuoteService quoteService, ILogger<AutoController> logger)
        {
            this.logger = logger;
            this.quoteService = quoteService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Quote()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Quote(AutoQuote quote)
        {
            if (ModelState.IsValid)
            {
                quoteService.GenerateAutoQuote(quote);
                return RedirectToAction("Index", "Insurance");
            }
            else
            {
                logger.LogInformation("Bad model", quote);
                return View(quote);
            }
        }

        [HttpGet]
        public IActionResult Person()
        {
            return View();
        }
    }
}
