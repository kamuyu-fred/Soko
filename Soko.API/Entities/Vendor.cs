namespace Soko.API.Entities;

public class Vendor
{
    public int VendorId { get; set; }
    public required string VendorName { get; set; }


    public int VendorPhone{ get; set; }

    public required string VendorLocation { get; set; }

    public DateOnly VendorAddedDate { get; set; }
}
   