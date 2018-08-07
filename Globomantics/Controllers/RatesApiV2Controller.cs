using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Services;
using Globomantics.Filters;
using Globomantics.Conventions;

namespace Globomantics.Controllers
{
    [ControllerVersion(Version = 2)]
    [RateExceptionFilter]
    [Route("api/rates")]
    public class RatesApiV2Controller : Controller
    {
        private IRateService rateService;

        public RatesApiV2Controller(IRateService rateService)
        {
            this.rateService = rateService;
        }

        [HttpGet]
        [Route("mortgage")]
        public IActionResult GetMortgageRates()
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
