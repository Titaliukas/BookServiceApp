namespace BookService.Contracts.Requests.Reservations;

public record CreateReservationRequest(int BookId, string Type, bool QuickPickUp, int Days);