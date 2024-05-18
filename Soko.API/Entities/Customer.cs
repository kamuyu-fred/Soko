namespace Soko.API.Entities;

public class Customer
{
    public int CustomerId { get; set; }
    public required string CustomerName { get; set; }


    public required int CustomerPhone{ get; set; }

    public required string CustomerLocation { get; set; }

    public DateOnly CustomerAddedDate { get; set; }
}
   