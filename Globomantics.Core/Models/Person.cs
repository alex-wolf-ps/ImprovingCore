using Globomantics.Core.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Globomantics.Models
{
    public class Person
    {
        // Person info
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [AgeValidator(Age = 18, ErrorMessage = "You must be 18 or older to apply")]
        public string Dob { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        // Address Info
        public string Street { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
    }
}
