using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using TestTemplateAI1.Core.Events;

namespace TestTemplateAI1.WorkerServices.FooService;

public class FooConsumer(ILogger<FooConsumer> Logger) : IConsumer<IFooEvent>
{
    public Task Consume(ConsumeContext<IFooEvent> context)
    {
        Logger.LogInformation("Talking from FooConsumer.");
        return Task.CompletedTask;
    }
}
