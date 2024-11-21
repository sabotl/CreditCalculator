using CreditCalculator.Application.Interfaces;
using CreditCalculator.Domain.Models.MainTask;

namespace CreditCalculator.Application.Services
{
    public class AnnuityLoanCalculatorService : IAnnuityLoanCalculator
    {
        public LoanResultModel CalculateAnnuitySchedule(LoanInputModel input)
        {
            var monthlyRate = CalculateMonthlyRate(input.AnnualInterestRate);
            var monthlyPayment = CalculateMonthlyPayment(input.LoanAmount, monthlyRate, input.LoanTerm);
            var payments = GeneratePaymentSchedule(input.LoanAmount, monthlyRate, monthlyPayment, input.LoanTerm);
            var totalOverpayment = CalculateTotalOverpayment(payments);

            return new LoanResultModel
            {
                MonthlyPayment = Math.Round(monthlyPayment, 2),
                TotalOverpayment = Math.Round(totalOverpayment, 2),
                Payments = payments.Select(p => new LoanPayment
                {
                    PaymentNumber = p.PaymentNumber,
                    PaymentDate = p.PaymentDate,
                    PrincipalPayment = Math.Round(p.PrincipalPayment, 2),
                    InterestPayment = Math.Round(p.InterestPayment, 2),
                    RemainingBalance = Math.Round(p.RemainingBalance, 2)
                }).ToList()
            };
        }

        private decimal CalculateMonthlyRate(decimal annualRate) => annualRate / 12 / 100;

        private decimal CalculateMonthlyPayment(decimal loanAmount, decimal monthlyRate, int loanTerm)
        {
            decimal baseValue = 1 + monthlyRate;
            decimal poweredValue = 1m;

            for (int i = 0; i < loanTerm; i++)
            {
                poweredValue *= baseValue;
            }

            decimal numerator = monthlyRate * poweredValue;
            decimal denominator = poweredValue - 1;

            decimal annuityFactor = numerator / denominator;

            return loanAmount * annuityFactor;
        }

        private List<LoanPayment> GeneratePaymentSchedule(decimal loanAmount, decimal monthlyRate, decimal monthlyPayment, int loanTerm)
        {
            var payments = new List<LoanPayment>();
            var balance = loanAmount;

            for (int i = 1; i <= loanTerm; i++)
            {
                var interestPayment = balance * monthlyRate;
                var principalPayment = monthlyPayment - interestPayment;
                balance -= principalPayment;

                payments.Add(new LoanPayment
                {
                    PaymentNumber = i,
                    PaymentDate = DateTime.Now.AddMonths(i),
                    PrincipalPayment = principalPayment,
                    InterestPayment = interestPayment,
                    RemainingBalance = balance
                });
            }

            return payments;
        }

        private decimal CalculateTotalOverpayment(IEnumerable<LoanPayment> payments) =>
            payments.Sum(p => p.InterestPayment);
    }
}
