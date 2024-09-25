namespace CQRS_MinimalAPI.Base;

public interface IEndpointBuilder
{
    void MapEndpoint(IEndpointRouteBuilder routeBuilder);
}