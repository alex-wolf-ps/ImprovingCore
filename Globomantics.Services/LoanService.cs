using Globomantics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Globomantics.Services
{
    public class LoanService : ILoanService
    {
        private List<LoanApplication> loans = new List<LoanApplication>();

        public void CreateLoanApplication(LoanDetails app, string loanId)
        {
            // We always just want one loan on our singleton for demo purposes
            loans.Clear();
            loans.Add(new LoanApplication()
            {
                LoanId = loanId,
                LoanInfo = app
            });
        }

        public void UpdateLoanEmployment(Employment employment)
        {
            var activeApplication = loans.FirstOrDefault();
            activeApplication.EmploymentInfo = employment;
        }

        public void UpdateLoanPersonalInfo(Person person)
        {
            var activeApplication = loans.FirstOrDefault();
            activeApplication.PersonalInfo = person;
        }

        public LoanApplication GetConfirmationDetails()
        {
            return loans.FirstOrDefault();
        }

        public void ConfirmApplication()
        {
            var activeApplication = loans.FirstOrDefault();
            activeApplication.LoanSubmitted = true;
        }
    }
}
