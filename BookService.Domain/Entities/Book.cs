namespace BookService.Domain.Entities;

public class Book : BaseEntity
{
    public string Title { get; set; }
    public int Year { get; set; }
    public string Type { get; set; }
}