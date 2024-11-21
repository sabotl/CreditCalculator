using CreditCalculator.Application.Interfaces;
using CreditCalculator.Application.Services;

namespace CreditCalculator.Application.DependencyInjection
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IAnnuityLoanCalculator, AnnuityLoanCalculatorService>();
            services.AddScoped<IDailyLoanCalculator, DailyLoanCalculatorService>();
            services.AddScoped<ILoanCalculatorService, LoanCalculatorService>();

            return services;
        }
    }
}
