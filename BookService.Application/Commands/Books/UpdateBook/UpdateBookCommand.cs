using MediatR;

namespace BookService.Application.Commands.Books.UpdateBook;

public record UpdateBookCommand(int Id, string Title, int Year, string Type, string Photo) : IRequest<Unit>;