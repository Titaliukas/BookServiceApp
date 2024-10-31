using MediatR;

namespace BookService.Application.Commands.Reservations.CreateReservation;

public record CreateReservationCommand(int BookId, string Type, bool QuickPickUp, int Days) : IRequest<int>;