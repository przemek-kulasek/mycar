using MediatR;
using Mycar.Application.Dtos;
using Mycar.Application.Queries.GetCarByVinQuery;

namespace Mycar.WebAPI.Endpoints
{
    public static class CarsEndpoints
    {
        public static WebApplication MapCarsEndpoints(this WebApplication app)
        {
            app.MapGet("/cars/{IdentificationNumber}", GetByVin)
                .Produces<CarDto>()
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithName("GetCarByVin")
                .WithOpenApi();

            return app;
        }

        private static async Task<IResult> GetByVin(IMediator mediator, [AsParameters] GetCarByVinQuery query)
        {
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }
    }
}
