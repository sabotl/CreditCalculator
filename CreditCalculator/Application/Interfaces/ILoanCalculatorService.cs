using CreditCalculator.Domain.Models.Daily;
using CreditCalculator.Domain.Models.MainTask;

namespace CreditCalculator.Application.Interfaces
{
    public interface ILoanCalculatorService
    {
        LoanResultModel CalculateAnnuitySchedule(LoanInputModel input);
        LoanCalculationResultModel CalculateDailySchedule(DailyLoanInputModel input);
    }

}
