﻿namespace CreditCalculator.Domain.Models.Daily
{
    public class PaymentScheduleItem
    {
        public int PaymentNumber { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal PrincipalPayment { get; set; }
        public decimal InterestPayment { get; set; }
        public decimal RemainingBalance { get; set; }
    }
}
