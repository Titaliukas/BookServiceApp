﻿using BookService.Contracts.Responses;
using BookService.Infrastructure;
using Mapster;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BookService.Application.Queries.Books.GetBooks;

public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, GetBooksResponse>
{
    private readonly BooksDbContext _booksDbContext;

    public GetBooksQueryHandler(BooksDbContext booksDbContext)
    {
        _booksDbContext = booksDbContext;
    }
    
    public async Task<GetBooksResponse> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var books = await _booksDbContext.Books.ToListAsync(cancellationToken);
        return books.Adapt<GetBooksResponse>();
    }
}