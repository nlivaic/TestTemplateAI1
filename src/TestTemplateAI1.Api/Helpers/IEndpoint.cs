using Microsoft.AspNetCore.Routing;

namespace TestTemplateAI1.Api.Helpers;

public interface IEndpoint
{
    public void Register(IEndpointRouteBuilder endpointRouteBuilder);
}
