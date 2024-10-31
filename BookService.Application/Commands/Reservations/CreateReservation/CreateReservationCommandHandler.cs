using BookService.Domain.Entities;
using BookService.Infrastructure;
using MediatR;

namespace BookService.Application.Commands.Reservations.CreateReservation;

public class CreateReservationCommandHandler : IRequestHandler<CreateReservationCommand, int>
{
    private readonly BooksDbContext _reservationsDbContext;

    public CreateReservationCommandHandler(BooksDbContext reservationsDbContext)
    {
        _reservationsDbContext = reservationsDbContext;
    }
    
    public async Task<int> Handle(CreateReservationCommand request, CancellationToken cancellationToken)
    {
        var reservation = new Reservation
        {
            BookId = request.BookId,
            Type = request.Type,
            QuickPickUp = request.QuickPickUp,
            Days = request.Days,
            Price = 0
        };
        
        if (reservation.Type == "Book") reservation.Price = reservation.Days * 2;
        else if (reservation.Type == "Audiobook") reservation.Price = reservation.Days * 3;
        if (reservation.Days > 3 && reservation.Days <= 10) reservation.Price *= 0.9m;
        else if (reservation.Days > 10 ) reservation.Price *= 0.8m;
        if (reservation.QuickPickUp) reservation.Price += 5;
        reservation.Price += 3;
        
        await _reservationsDbContext.Reservations.AddAsync(reservation, cancellationToken);
        await _reservationsDbContext.SaveChangesAsync(cancellationToken);
        
        return reservation.Id;
    }
}