using BookService.Domain.Entities;
using BookService.Infrastructure;
using MediatR;

namespace BookService.Application.Commands.Books.CreateBook;

public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
{
    private readonly BooksDbContext _booksDbcontext;
    
    public CreateBookCommandHandler(BooksDbContext booksDbContext)
    {
        _booksDbcontext = booksDbContext;
    }
    
    public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
    {
        var book = new Book
        {
            Title = request.Title,
            Year = Convert.ToInt32(request.Year),
            CreateDate = DateTime.Now.ToUniversalTime()
        };
        
        await _booksDbcontext.Books.AddAsync(book, cancellationToken);
        await _booksDbcontext.SaveChangesAsync(cancellationToken);
        
        return book.Id;
    }
}