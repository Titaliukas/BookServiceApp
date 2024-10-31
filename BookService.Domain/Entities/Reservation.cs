namespace BookService.Domain.Entities;

public class Reservation : BaseEntity
{
    public string BookId { get; set; }
    public string Type { get; set; }
    public bool QuickPickUp { get; set; }
    public int Days { get; set; }
    public decimal Price { get; set; }
}