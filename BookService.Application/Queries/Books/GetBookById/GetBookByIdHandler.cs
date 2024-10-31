using BookService.Contracts.Responses;
using BookService.Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookService.Application.Queries.Books.GetBookById;

public class GetBookByIdHandler : IRequestHandler<GetBookByIdQuery, GetBookByIdResponse>
{
    private readonly BooksDbContext _booksDbContext;

    public GetBookByIdHandler(BooksDbContext booksDbContext)
    {
        _booksDbContext = booksDbContext;
    }
    
    public async Task<GetBookByIdResponse> Handle(GetBookByIdQuery request, CancellationToken cancellationToken)
    {
        var book = await _booksDbContext.Books.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (book == null)
        {
            throw new KeyNotFoundException();
        }
        
        return book.Adapt<GetBookByIdResponse>();
    }
}