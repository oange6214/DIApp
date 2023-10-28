using DIApp.Services;
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
    private readonly FirstService _firstService;

    public WeatherForecastController(
        ILogger<WeatherForecastController> logger,
        IOperationTransient transientOp,
        IOperationScoped scopedOp,
        IOperationSingleton singletonOp,
        FirstService firstService)
    {
        _logger = logger;
        _transientOp = transientOp;
        _scopedOp = scopedOp;
        _singletonOp = singletonOp;
        _firstService = firstService;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IActionResult Get()
    {
        _logger.LogInformation("Hello from logger\n");
        _logger.LogInformation($"Transient: {_transientOp.OperationId}\n");
        _logger.LogInformation($"Scoped: {_scopedOp.OperationId}\n");
        _logger.LogInformation($"Singleton: {_singletonOp.OperationId}\n");

        _firstService.GenerateResult();

        return Ok();
    }
}
