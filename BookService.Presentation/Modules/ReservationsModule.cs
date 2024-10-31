using BookService.Application.Commands.Books.CreateBook;
using BookService.Application.Commands.Books.DeleteBook;
using BookService.Application.Commands.Reservations.CreateReservation;
using BookService.Application.Commands.Reservations.DeleteReservation;
using BookService.Application.Queries.Books.GetBooks;
using BookService.Application.Queries.Reservations.GetReservations;
using BookService.Contracts.Requests.Books;
using BookService.Contracts.Requests.Reservations;
using MediatR;

namespace BookService.Modules;

public static class ReservationsModule
{
    public static void AddReservationsEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/reservations", async (IMediator mediator, CancellationToken ct) =>
        {
            var reservations = await mediator.Send(new GetReservationsQuery(), ct);
            return Results.Ok(reservations);
        }).WithTags("Reservations");
        
        app.MapPost("/api/reservations", async (IMediator mediator, CreateReservationRequest createReservationRequest, CancellationToken ct) =>
        {
            var command = new CreateReservationCommand(createReservationRequest.BookId, createReservationRequest.Type, createReservationRequest.QuickPickUp, createReservationRequest.Days);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Reservations");
        
        app.MapDelete("/api/reservations/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
        {
            var command = new DeleteReservationCommand(id);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Reservations");
    }
}