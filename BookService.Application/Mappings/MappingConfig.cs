using System.Runtime.InteropServices;
using BookService.Contracts.Responses;
using BookService.Domain.Entities;
using Mapster;

namespace BookService.Application.Mappings;

public class MappingConfig
{
    public static void Configure()
    {
        TypeAdapterConfig<List<Book>, GetBooksResponse>.NewConfig()
            .Map(dest => dest.BookDtos, src => src);
        
        TypeAdapterConfig<Book, GetBookByIdResponse>.NewConfig()
            .Map(dest => dest.BookDto, src => src);
    }
}