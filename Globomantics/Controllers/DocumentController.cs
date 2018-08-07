using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Globomantics.Models;
using Globomantics.Services;
using System.Text;
using System.IO;

namespace Globomantics.Controllers
{
    public class DocumentController : Controller
    {
        private IRateService rateService;

        public DocumentController(IRateService rateService)
        {
            this.rateService = rateService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetCDRates()
        {
            var cdRates = rateService.GetCDRates();

            var builder = new StringBuilder();
            var stringWriter = new StringWriter(builder);

            foreach (var rate in cdRates)
            {
                var properties = rate.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    stringWriter.Write(GetValue(rate, prop.Name));
                    stringWriter.Write(", ");
                }
                stringWriter.WriteLine();
            }

            return new FileContentResult(
                Encoding.ASCII.GetBytes(stringWriter.ToString()), "text/csv")
                { FileDownloadName = "CDRates.csv" };
        }

        public IActionResult GetMortgageRates()
        {
            var cdRates = rateService.GetCDRates();

            var builder = new StringBuilder();
            var stringWriter = new StringWriter(builder);

            foreach (var rate in cdRates)
            {
                var properties = rate.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    stringWriter.Write(GetValue(rate, prop.Name));
                    stringWriter.Write(", ");
                }
                stringWriter.WriteLine();
            }

            return new FileContentResult(Encoding.ASCII.GetBytes(stringWriter.ToString()), "text/csv") { FileDownloadName = "MortgageRates.csv" };
        }

        public IActionResult GetCreditCardRates()
        {
            var cdRates = rateService.GetCreditCardRates();

            var builder = new StringBuilder();
            var stringWriter = new StringWriter(builder);

            foreach (var rate in cdRates)
            {
                var properties = rate.GetType().GetProperties();
                foreach (var prop in properties)
                {
                    stringWriter.Write(GetValue(rate, prop.Name));
                    stringWriter.Write(", ");
                }
                stringWriter.WriteLine();
            }

            return new FileContentResult(Encoding.ASCII.GetBytes(stringWriter.ToString()), "text/csv") { FileDownloadName = "CreditCardRates.csv" };
        }

        public static string GetValue(object item, string propName)
        {
            return item.GetType().GetProperty(propName).GetValue(item, null).ToString() ?? "";
        }
    }
}
