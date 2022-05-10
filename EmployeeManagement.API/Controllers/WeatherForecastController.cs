using Contracts;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ILoggerManager _logger;
        public WeatherForecastController(ILoggerManager logger)
        {
            _logger = logger;
        }

        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _logger.LogInfo("Information message log");
            _logger.LogDebug("Debug message log");
            _logger.LogWarning("Warning message log");
            _logger.LogError("Error message log");

            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}