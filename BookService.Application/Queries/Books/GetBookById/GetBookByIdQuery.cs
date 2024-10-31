using BookService.Contracts.Responses;
using MediatR;

namespace BookService.Application.Queries.Books.GetBookById;

public record GetBookByIdQuery(int Id) : IRequest<GetBookByIdResponse>;