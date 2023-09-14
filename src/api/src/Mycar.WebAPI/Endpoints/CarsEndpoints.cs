﻿using MediatR;
using Mycar.Application.Commands.CreateCarCommand;
using Mycar.Application.Commands.DeleteCarCommand;
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

            app.MapPost("/cars/", Post)
                .Produces(StatusCodes.Status201Created)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithName("CreateCar")
                .WithOpenApi();

            app.MapDelete("/cars/", Delete)
                .Produces(StatusCodes.Status204NoContent)
                .Produces(StatusCodes.Status400BadRequest)
                .Produces(StatusCodes.Status401Unauthorized)
                .Produces(StatusCodes.Status404NotFound)
                .Produces(StatusCodes.Status500InternalServerError)
                .WithName("DeleteCar")
                .WithOpenApi();

            return app;
        }

        private static async Task<IResult> GetByVin(IMediator mediator, [AsParameters] GetCarByVinQuery query)
        {
            var result = await mediator.Send(query);
            return Results.Ok(result);
        }

        private static async Task<IResult> Post(IMediator mediator, [AsParameters] CreateCarCommand command)
        {
            var result = await mediator.Send(command);
            return Results.Created("/Cars/", new { id = result });
        }

        private static async Task<IResult> Delete(IMediator mediator, [AsParameters] DeleteCarCommand command)
        {
            await mediator.Send(command);
            return Results.NoContent();
        }
    }
}
