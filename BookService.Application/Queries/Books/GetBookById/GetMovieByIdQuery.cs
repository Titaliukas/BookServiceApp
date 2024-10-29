using BookService.Contracts.Responses;
using MediatR;

namespace BookService.Application.Queries.Books.GetBookById;

public record GetMovieByIdQuery(int Id) : IRequest<GetBookByIdResponse>;