using BookService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookService.Infrastructure;

public class BooksDbContext : DbContext
{
    public BooksDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Book> Books { get; set; }
    
    public DbSet<Reservation> Reservations { get; set; }
}