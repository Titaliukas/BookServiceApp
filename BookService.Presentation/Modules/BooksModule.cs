using BookService.Application.Commands.Books.CreateBook;
using BookService.Application.Commands.Books.DeleteBook;
using BookService.Application.Queries.Books.GetBookById;
using BookService.Application.Queries.Books.GetBooks;
using BookService.Contracts.Requests.Books;
using BookService.Contracts.Responses;
using MediatR;

namespace BookService.Modules;

public static class BooksModule
{
    public static void AddBooksEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/books", async (IMediator mediator, CancellationToken ct) =>
        {
            var books = await mediator.Send(new GetBooksQuery(), ct);
            return Results.Ok(books);
        }).WithTags("Books");
        
        app.MapGet("/api/books/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
        {
            var book = await mediator.Send(new GetBookByIdQuery(id), ct);
            return Results.Ok(book);
        }).WithTags("Books");
        
        app.MapPost("/api/books", async (IMediator mediator, CreateBookRequest createBookRequest, CancellationToken ct) =>
            {
                var command = new CreateBookCommand(createBookRequest.Title, createBookRequest.Year, createBookRequest.Type, createBookRequest.Photo);
                var result = await mediator.Send(command, ct);
                return Results.Ok(result);
            }).WithTags("Books");
        
        app.MapDelete("/api/books/{id}", async (IMediator mediator, int id, CancellationToken ct) =>
        {
            var command = new DeleteBookCommand(id);
            var result = await mediator.Send(command, ct);
            return Results.Ok(result);
        }).WithTags("Books");
    }
}