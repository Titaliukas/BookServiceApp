using BookService.Infrastructure;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookService.Application.Commands.Books.UpdateBook;

public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
{
    private readonly BooksDbContext _booksDbContext;

    public UpdateBookCommandHandler(BooksDbContext booksDbContext)
    {
        _booksDbContext = booksDbContext;
    }
    
    public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
    {
        var bookToUpdate = await _booksDbContext.Books.FirstOrDefaultAsync(x => x.Id == request.Id, cancellationToken);

        if (bookToUpdate == null)
        {
            throw new NullReferenceException("Book not found");
        }
        
        bookToUpdate.Title = request.Title;
        bookToUpdate.Year = request.Year;
        bookToUpdate.Photo = request.Photo;
        bookToUpdate.Type = request.Type;
        
        _booksDbContext.Books.Update(bookToUpdate);
        await _booksDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}