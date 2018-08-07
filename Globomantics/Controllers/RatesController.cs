using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Services;
using Globomantics.Filters;

namespace Globomantics.Controllers
{
    [RateExceptionFilter]
    public class RatesController : Controller
    {
        private IRateService rateService;

        public RatesController(IRateService rateService)
        {
            this.rateService = rateService;
        }

        [HttpGet]
        [Route("api/rates/mortgage")]
        [Route("api/{version:versionCheck(1)}/rates/mortgage")]
        public IActionResult GetMortgageRates()
        {
            return Ok(rateService.GetMortgageRates());
        }

        [HttpGet]
        [Route("api/{version:versionCheck(2)}/rates/mortgage")]
        public IActionResult GetMortgageRatesV2()
        {
            return Ok(rateService.GetMortgageRateDetails());
        }

        [HttpGet]
        [Route("autoloan")]
        public IActionResult GetAutoLoanRates()
        {
            return Ok(rateService.GetAutoLoanRates());
        }

        [HttpGet]
        [Route("creditcard")]
        public IActionResult GetCreditCardRates()
        {
            return Ok(rateService.GetCreditCardRates());
        }


        [HttpGet]
        [Route("cd")]
        public IActionResult GetCDRates()
        {
            return Ok(rateService.GetCDRates());
        }
    }
}
