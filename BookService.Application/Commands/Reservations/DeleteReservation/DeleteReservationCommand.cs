using MediatR;

namespace BookService.Application.Commands.Reservations.DeleteReservation;

public record DeleteReservationCommand(int Id) : IRequest<Unit>;