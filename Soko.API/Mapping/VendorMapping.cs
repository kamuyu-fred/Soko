using Soko.API.Dtos;
using Soko.API.Entities;

namespace Soko.API.Mapping;

public static class VendorMapping
{
    public static Vendor ToEntity(this CreateVendorDto vendor)
    {
        return new Vendor()
        {   
            VendorName = vendor.VendorName,
            VendorPhone = vendor.VendorPhone,
            VendorLocation = vendor.VendorLocation,
            VendorAddedDate = vendor.VendorAddedDate
            
        };
    }

    public static Vendor ToEntity(this UpdateVendorDto vendor, int VendorId)
    {
        return new Vendor()
        {
            VendorId =VendorId,
            VendorName =vendor.VendorName,
            VendorPhone = vendor.VendorPhone,
            VendorLocation = vendor.VendorLocation,
            VendorAddedDate = vendor.VendorAddedDate
            
        };
    }    

   

    public static VendorDetailsDto ToVendorDetailsDto(this Vendor vendor)
    {
        return new(

            vendor.VendorId,
            vendor.VendorName,
            vendor.VendorPhone,
            vendor.VendorLocation,
            vendor.VendorAddedDate
        );
    }    
}
