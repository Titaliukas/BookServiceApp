namespace BookService.Contracts.Dtos;

public record ReservationDto(string BookId, string Type, bool QuickPickUp, int Days, decimal Price);