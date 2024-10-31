using BookService.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookService.Application.Commands.Reservations.DeleteReservation;

public class DeleteReservationCommandHandler : IRequestHandler<DeleteReservationCommand, Unit>
{
    private readonly BooksDbContext _reservationsDbContext;

    public DeleteReservationCommandHandler(BooksDbContext reservationsDbContext)
    {
        _reservationsDbContext = reservationsDbContext;
    }
    
    public async Task<Unit> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
    {
        var ReservationToDelete = 
            await _reservationsDbContext.Reservations
                .FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (ReservationToDelete is null)
        {
            throw new KeyNotFoundException();
        }
        
        _reservationsDbContext.Reservations.Remove(ReservationToDelete);
        await _reservationsDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}