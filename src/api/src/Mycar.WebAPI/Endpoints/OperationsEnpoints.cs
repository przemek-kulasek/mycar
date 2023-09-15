using MediatR;
using Mycar.Application.Commands.CreateOperationCommand;
using Mycar.Application.Dtos;
using Mycar.Application.Queries.GetOperationsByCarIdQuery;

namespace Mycar.WebAPI.Endpoints
{
    public static class OperationsEnpoints
    {
        public static WebApplication MapOperationsEndpoints(this WebApplication app)
        {
            app.MapGet("/cars/{CarId}/operations", GetByCarId)
                .Produces<ICollection<OperationDto>>()
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithName("GetOperationsByCarId")
                .WithOpenApi();

            app.MapPost("/cars/{CarId}/operations", Post)
                .Produces(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithName("CreateOperation")
                .WithOpenApi();

            return app;
        }

        private static async Task<IResult> GetByCarId(IMediator mediator, [AsParameters] GetOperationsByCarIdQuery query)
        {
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }

        private static async Task<IResult> Post(IMediator mediator, [AsParameters] CreateOperationCommand command)
        {
            var result = await mediator.Send(command);
            return Results.Created($"/cars/{command.CarId}/operations/{result}", new { id = result });
        }
    }
}
