using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Services;
using Microsoft.AspNetCore.Session;
using Microsoft.AspNetCore.Http;
using Globomantics.Filters;

namespace Globomantics.Controllers
{
    [TypeFilter(typeof(FeatureAuthFilter),
        Arguments = new object[] { "Loan" })]
    public class LoanController : Controller
    {
        private ILoanService loanService;

        public LoanController(ILoanService loanService)
        {
            this.loanService = loanService;
        }

        public IActionResult Application()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Application(LoanDetails app)
        {
            loanService.CreateLoanApplication(app, Guid.NewGuid().ToString());

            return RedirectToAction("Employment");
        }

        [HttpGet]
        public IActionResult Employment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Employment(Employment employment)
        {
            loanService.UpdateLoanEmployment(employment);
            return RedirectToAction("Personal");
        }

        [HttpGet]
        public IActionResult Personal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Personal(Person person)
        {
            loanService.UpdateLoanPersonalInfo(person);
            return RedirectToAction("Confirmation");
        }

        [HttpGet]
        public IActionResult Confirmation()
        {
            var loan = loanService.GetConfirmationDetails();
            return View(loan);
        }

        [HttpGet]
        public IActionResult Success()
        {
            return View();
        }
    }
}
