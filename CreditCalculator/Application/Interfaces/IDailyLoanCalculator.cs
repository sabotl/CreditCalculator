using CreditCalculator.Domain.Models.Daily;

namespace CreditCalculator.Application.Interfaces
{
    public interface IDailyLoanCalculator
    {
        LoanCalculationResultModel CalculateDailySchedule(DailyLoanInputModel input);
    }
}
