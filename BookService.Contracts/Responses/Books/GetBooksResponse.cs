using BookService.Contracts.Dtos;

namespace BookService.Contracts.Responses;

public record GetBooksResponse(List<BookDto> BookDtos);