namespace CreditCalculator.Domain.Models.MainTask
{
    public class LoanResultModel
    {
        public decimal MonthlyPayment { get; set; }
        public decimal TotalOverpayment { get; set; }
        public List<LoanPayment> Payments { get; set; }
    }

}
