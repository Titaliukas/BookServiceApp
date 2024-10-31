using BookService.Contracts.Dtos;

namespace BookService.Contracts.Responses.Reservations;

public record GetReservationsResponse(List<ReservationDto> ReservationDtos);