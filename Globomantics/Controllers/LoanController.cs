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

namespace Globomantics.Controllers
{
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
            if (ModelState.IsValid)
            {
                loanService.CreateLoanApplication(app, Guid.NewGuid().ToString());
                return RedirectToAction("Employment");
            }

            return View(app);
        }

        [HttpGet]
        public IActionResult Employment()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Employment(Employment employment)
        {
            if (ModelState.IsValid)
            {
                loanService.UpdateLoanEmployment(employment);
                return RedirectToAction("Personal");
            }

            return View(employment);
        }

        [HttpGet]
        public IActionResult Personal()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Personal(Person person)
        {
            if (ModelState.IsValid)
            {
                loanService.UpdateLoanPersonalInfo(person);
                return RedirectToAction("Confirmation");
            }

            return View(person);
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
