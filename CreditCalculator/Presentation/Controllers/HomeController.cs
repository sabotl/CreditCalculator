using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CreditCalculator.Application.Interfaces;

namespace CreditCalculator.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly ILoanCalculatorService _loanCalculatorService;

    public HomeController(ILoanCalculatorService loanCalculatorService)
    {
        _loanCalculatorService = loanCalculatorService;
    }

    public IActionResult Index() => View();

    public IActionResult Privacy() => View();

    [HttpPost]
    public IActionResult Calculate(LoanInputModel model)
    {
        if (!ModelState.IsValid)
            return View("Index");

        try
        {
            var result = _loanCalculatorService.CalculateAnnuitySchedule(model);
            return View("Result", result);
        }
        catch (Exception ex)
        {
            ModelState.AddModelError("", "Произошла ошибка при расчете графика платежей.");
            return View("Index");
        }

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error() =>
        View(new CreditCalculator.Domain.Models.ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
}
