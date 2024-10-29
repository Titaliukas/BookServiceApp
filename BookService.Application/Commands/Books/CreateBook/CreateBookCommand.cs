using MediatR;

namespace BookService.Application.Commands.Books.CreateBook;

public record CreateBookCommand(string Title, string Year) : IRequest<int>;