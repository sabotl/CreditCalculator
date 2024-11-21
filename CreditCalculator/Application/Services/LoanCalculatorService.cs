using CreditCalculator.Application.Interfaces;
using CreditCalculator.Domain.Models.Daily;
using CreditCalculator.Domain.Models.MainTask;

namespace CreditCalculator.Application.Services
{
    public class LoanCalculatorService : ILoanCalculatorService
    {
        private readonly IAnnuityLoanCalculator _annuityCalculator;
        private readonly IDailyLoanCalculator _dailyCalculator;

        public LoanCalculatorService(IAnnuityLoanCalculator annuityCalculator, IDailyLoanCalculator dailyCalculator)
        {
            _annuityCalculator = annuityCalculator;
            _dailyCalculator = dailyCalculator;
        }

        public LoanResultModel CalculateAnnuitySchedule(LoanInputModel input) =>
            _annuityCalculator.CalculateAnnuitySchedule(input);

        public LoanCalculationResultModel CalculateDailySchedule(DailyLoanInputModel input) =>
            _dailyCalculator.CalculateDailySchedule(input);
    }
}
