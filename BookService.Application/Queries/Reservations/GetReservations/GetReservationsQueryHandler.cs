using BookService.Application.Queries.Books.GetBooks;
using BookService.Contracts.Responses;
using BookService.Contracts.Responses.Reservations;
using BookService.Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookService.Application.Queries.Reservations.GetReservations;

public class GetReservationsQueryHandler : IRequestHandler<GetReservationsQuery, GetReservationsResponse>
{
    private readonly BooksDbContext _reservationsDbContext;

    public GetReservationsQueryHandler(BooksDbContext reservationsDbContext)
    {
        _reservationsDbContext = reservationsDbContext;
    }
    
    public async Task<GetReservationsResponse> Handle(GetReservationsQuery request, CancellationToken cancellationToken)
    {
        var books = await _reservationsDbContext.Reservations.ToListAsync(cancellationToken);
        return books.Adapt<GetReservationsResponse>();
    }
}