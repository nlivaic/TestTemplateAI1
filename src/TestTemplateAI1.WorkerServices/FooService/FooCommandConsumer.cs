using System.Threading.Tasks;
using MassTransit;
using Microsoft.Extensions.Logging;
using TestTemplateAI1.Core.Events;
using TestTemplateAI1.Data;

namespace TestTemplateAI1.WorkerServices.FooService;

public class FooCommandConsumer(ILogger<FooCommandConsumer> Logger)
    : IConsumer<IFooCommand>
{
    public Task Consume(ConsumeContext<IFooCommand> context)
    {
        Logger.LogInformation("Talking from FooCommandConsumer.");
        return Task.CompletedTask;
    }

    public class FooCommandConsumerDefinition : ConsumerDefinition<FooCommandConsumer>
    {
        public FooCommandConsumerDefinition()
        {
            EndpointName = $"{WorkerAssemblyInfo.ServiceName.ToLower()}-foo-command-queue";
        }

        protected override void ConfigureConsumer(
            IReceiveEndpointConfigurator endpointConfigurator,
            IConsumerConfigurator<FooCommandConsumer> consumerConfigurator,
            IRegistrationContext context)
        {
            // Configure message retry with millisecond intervals.
            // endpointConfigurator.UseMessageRetry(r => r.Intervals(100, 200, 500, 800, 1000));
            // Creates only a queue, without topic and subscription.
            // endpointConfigurator.ConfigureConsumeTopology = false;

            // Use the outbox to prevent duplicate events from being published.
            endpointConfigurator.UseEntityFrameworkOutbox<TestTemplateAI1DbContext>(context);
        }
    }
}
