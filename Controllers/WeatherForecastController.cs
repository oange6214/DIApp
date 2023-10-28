using DIApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DIApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly ILogger<WeatherForecastController> _logger;
    private readonly IOperationTransient _transientOp;
    private readonly IOperationScoped _scopedOp;
    private readonly IOperationSingleton _singletonOp;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger, 
        IOperationTransient transientOp, 
        IOperationScoped scopedOp, 
        IOperationSingleton singletonOp)
    {
        _logger = logger;
        _transientOp = transientOp;
        _scopedOp = scopedOp;
        _singletonOp = singletonOp;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        _logger.LogInformation("Hello from logger");

        return Ok();
    }
}
