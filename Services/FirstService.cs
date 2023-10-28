using DIApp.Services.Interfaces;

namespace DIApp.Services;

public class FirstService
{
    private readonly ILogger<FirstService> _logger;
    private readonly IOperationTransient _transientOp;
    private readonly IOperationScoped _scopedOp;
    private readonly IOperationSingleton _singletonOp;

    public FirstService(
        ILogger<FirstService> logger, 
        IOperationTransient transientOp, 
        IOperationScoped scopedOp, 
        IOperationSingleton singletonOp)
    {
        _logger = logger;
        _transientOp = transientOp;
        _scopedOp = scopedOp;
        _singletonOp = singletonOp;
    }

    public void GenerateResult()
    {
        _logger.LogInformation($"FirstService - Transient: {_transientOp.OperationId}\n");
        _logger.LogInformation($"FirstService - Scoped: {_scopedOp.OperationId}\n");
        _logger.LogInformation($"FirstService - Singleton: {_singletonOp.OperationId}\n");
    }

}