using DIApp.Services.Interfaces;

namespace DIApp.Services;

public class Operation : IOperationScoped, IOperationTransient, IOperationSingleton
{
    public string OperationId { get; }

    public Operation()
    {
        OperationId = Guid.NewGuid().ToString()[^6..];
    }
}