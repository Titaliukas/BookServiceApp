using BookService.Contracts.Responses;
using MediatR;

namespace BookService.Application.Queries.Books.GetBooks;

public record GetBooksQuery() : IRequest<GetBooksResponse>;