using BookService.Contracts.Dtos;

namespace BookService.Contracts.Responses;

public record GetBookByIdResponse(BookDto BookDto);