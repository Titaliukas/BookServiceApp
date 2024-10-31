namespace BookService.Contracts.Requests.Books;

public record UpdateBookRequest(string Title, int Year, string Type, string Photo);