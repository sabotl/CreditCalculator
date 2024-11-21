using System.ComponentModel.DataAnnotations;

namespace CreditCalculator.Domain.Models.Daily
{
    public class DailyLoanInputModel
    {
        [Required(ErrorMessage = "Введите сумму займа.")]
        [Range(1000, 10000000, ErrorMessage = "Сумма займа должна быть от 1 000 до 10 000 000.")]
        public decimal LoanAmount { get; set; }

        [Required(ErrorMessage = "Введите срок займа.")]
        [Range(1, 3650, ErrorMessage = "Срок займа должен быть от 1 до 3650 дней.")]
        public int LoanTermDays { get; set; }

        [Required(ErrorMessage = "Введите ставку.")]
        [Range(0.01, 10, ErrorMessage = "Ставка должна быть от 0.01% до 10%.")]
        public decimal DailyRate { get; set; }

        [Required(ErrorMessage = "Введите шаг платежа.")]
        [Range(1, 365, ErrorMessage = "Шаг платежа должен быть от 1 до 365 дней.")]
        public int PaymentStepDays { get; set; }
    }
}
