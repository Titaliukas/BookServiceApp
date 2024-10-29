using MediatR;

namespace BookService.Application.Commands.Books.DeleteBook;

public record DeleteBookCommand(int Id) : IRequest<Unit>;