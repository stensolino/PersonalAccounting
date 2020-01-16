using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using PersonalAccounting.Web.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace PersonalAccounting.Web.Data
{
    public class WeatherForecastService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IBudgetService _budgetService;
        public WeatherForecastService(IHttpContextAccessor httpContextAccessor, IBudgetService budgetService)
        {
            _httpContextAccessor = httpContextAccessor;
            _budgetService = budgetService;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        public Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            // Example: Get access_token - user has to be signed in
            var accessToken = _httpContextAccessor.HttpContext.GetTokenAsync("access_token").Result;
            // Example: HttpClient request
            _budgetService.GetBudget(1);

            var rng = new Random();
            return Task.FromResult(Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = startDate.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            }).ToArray());
        }
    }
}
