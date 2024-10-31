namespace BookService.Contracts.Requests.Books;

public record CreateBookRequest(string Title, int Year, string Type, string Photo);