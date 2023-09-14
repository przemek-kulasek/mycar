using MediatR;
using Mycar.Application.Commands.CreateItemCommand;
using Mycar.Application.Dtos;
using Mycar.Application.Queries.GetItemsByOperationIdQuery;

namespace Mycar.WebAPI.Endpoints
{
    public static class ItemsEndpoints
    {
        public static WebApplication MapItemsEndpoints(this WebApplication app)
        {
            app.MapGet("/cars/{CarId}/operations/{OperationId}/items", GetByOperationId)
                .Produces<ICollection<OperationDto>>()
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithName("GetItemsByOperationId")
                .WithOpenApi();

            app.MapPost("/cars/{CarId}/operations/{OperationId}/items", Post)
                .Produces(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithName("CreateItem")
                .WithOpenApi();

            return app;
        }

        private static async Task<IResult> GetByOperationId(IMediator mediator, Guid carId, [AsParameters] GetItemsByOperationIdQuery query)
        {
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }

        private static async Task<IResult> Post(IMediator mediator, Guid carId, [AsParameters] CreateItemCommand command)
        {
            var result = await mediator.Send(command);
            return Results.Created($"/cars/{carId}/operations/{command.Item.OperationId}/items", new { id = result });
        }
    }
}
