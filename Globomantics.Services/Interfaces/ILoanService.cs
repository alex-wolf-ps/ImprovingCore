using Globomantics.Models;

namespace Globomantics.Services
{
    public interface ILoanService
    {
        void CreateLoanApplication(LoanDetails details, string loanId);

        void UpdateLoanEmployment(Employment employment);

        void UpdateLoanPersonalInfo(Person person);

        LoanApplication GetConfirmationDetails();

        void ConfirmApplication();
    }
}