using CreditCalculator.Application.Interfaces;
using CreditCalculator.Domain.Models.Daily;

namespace CreditCalculator.Application.Services
{
    public class DailyLoanCalculatorService : IDailyLoanCalculator
    {
        public LoanCalculationResultModel CalculateDailySchedule(DailyLoanInputModel input)
        {
            var dailyRate = input.DailyRate / 100;
            var balance = input.LoanAmount;
            var paymentSchedule = new List<PaymentScheduleItem>();
            var totalInterest = 0m;

            for (int i = 1, paymentNumber = 1; i <= input.LoanTermDays; i += input.PaymentStepDays, paymentNumber++)
            {
                var interestPayment = balance * dailyRate * input.PaymentStepDays;
                var principalPayment = input.PaymentStepDays == input.LoanTermDays - i + 1
                    ? balance
                    : input.LoanAmount / (input.LoanTermDays / input.PaymentStepDays);

                balance -= principalPayment;

                paymentSchedule.Add(new PaymentScheduleItem
                {
                    PaymentNumber = paymentNumber,
                    PaymentDate = DateTime.Now.AddDays(i),
                    PrincipalPayment = Math.Round(principalPayment, 2),
                    InterestPayment = Math.Round(interestPayment, 2),
                    RemainingBalance = Math.Round(balance, 2)
                });

                totalInterest += interestPayment;
                if (balance <= 0)
                {
                    break;
                }
            }

            return new LoanCalculationResultModel
            {
                LoanAmount = input.LoanAmount,
                LoanTermDays = input.LoanTermDays,
                DailyRate = input.DailyRate,
                TotalRepayment = Math.Round(input.LoanAmount + totalInterest, 2),
                TotalInterest = Math.Round(totalInterest, 2),
                PaymentSchedule = paymentSchedule
            };
        }
    }
}
