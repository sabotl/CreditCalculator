using CreditCalculator.Application.Interfaces;
using CreditCalculator.Domain.Models.Daily;
using Microsoft.AspNetCore.Mvc;

namespace CreditCalculator.Presentation.Controllers
{
    public class LoanDailyCalculatorController : Controller
    {
        private readonly ILoanCalculatorService _loanCalculatorService;
        public LoanDailyCalculatorController(ILoanCalculatorService loanCalculatorService)
        {
            _loanCalculatorService = loanCalculatorService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CalculateDailySchedule([FromForm] DailyLoanInputModel input)
        {
            if (!ModelState.IsValid)
                return View("Index");
            try
            {
                var result = _loanCalculatorService.CalculateDailySchedule(input);
                return View("Result", result);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Произошла ошибка при расчете графика платежей.");
                return View("Index");
            }
        }
    }
}
