using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Globomantics.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace Globomantics.Controllers
{
    public class SurveyController : Controller
    {
        public IActionResult Submission(List<Submission> submissions)
        {
            // TODO: Save submissions
            return View();
        }
    }
}