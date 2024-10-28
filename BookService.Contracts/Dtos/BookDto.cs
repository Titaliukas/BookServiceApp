namespace BookService.Contracts.Dtos;

public record BookDto(int Id, string Title, int Year, string Type, DateTime PublishDate);