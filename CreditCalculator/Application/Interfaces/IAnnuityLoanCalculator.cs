using CreditCalculator.Domain.Models.MainTask;

namespace CreditCalculator.Application.Interfaces
{
    public interface IAnnuityLoanCalculator
    {
        LoanResultModel CalculateAnnuitySchedule(LoanInputModel input);
    }
}
