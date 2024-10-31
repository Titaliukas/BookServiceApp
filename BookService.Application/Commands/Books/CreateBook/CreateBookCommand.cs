using MediatR;

namespace BookService.Application.Commands.Books.CreateBook;

public record CreateBookCommand(string Title, int Year, string Type, string Photo) : IRequest<int>;