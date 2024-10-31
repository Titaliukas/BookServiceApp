using BookService.Contracts.Responses.Reservations;
using MediatR;

namespace BookService.Application.Queries.Reservations.GetReservations;

public record GetReservationsQuery() : IRequest<GetReservationsResponse>;