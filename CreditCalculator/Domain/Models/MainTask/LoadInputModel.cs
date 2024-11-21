using System.ComponentModel.DataAnnotations;

public class LoanInputModel
{
    [Required(ErrorMessage = "Введите сумму займа.")]
    [Range(1000, 10000000, ErrorMessage = "Сумма займа должна быть от 1000 до 10 000 000.")]
    public decimal LoanAmount { get; set; }

    [Required(ErrorMessage = "Введите срок займа.")]
    [Range(1, 360, ErrorMessage = "Срок займа должен быть от 1 до 360 месяцев.")]
    public int LoanTerm { get; set; }

    [Required(ErrorMessage = "Введите ставку.")]
    [Range(1, 100, ErrorMessage = "Ставка должна быть от 1% до 100%.")]
    public decimal AnnualInterestRate{ get; set; }

}
