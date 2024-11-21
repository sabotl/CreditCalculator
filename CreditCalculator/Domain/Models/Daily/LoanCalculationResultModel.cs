namespace CreditCalculator.Domain.Models.Daily
{
    public class LoanCalculationResultModel
    {
        public decimal LoanAmount { get; set; }
        public int LoanTermDays { get; set; }
        public decimal DailyRate { get; set; }
        public decimal TotalRepayment { get; set; }
        public decimal TotalInterest { get; set; }
        public List<PaymentScheduleItem> PaymentSchedule { get; set; } = new List<PaymentScheduleItem>();
    }

}
