using Soko.API.Dtos;
using Soko.API.Entities;

namespace Soko.API.Mapping;

public static class POSBuyMapping
{
    public static POSBuy ToEntity(this CreatePOSBuyDto pbuytransaction)
    {
        return new POSBuy()
        {
            PBTId = pbuytransaction.PBTId,
            PTVendorName = pbuytransaction.PTVendorName,
            PBTQuantity = pbuytransaction.PBTQuantity,
            PTProductId = pbuytransaction.PTProductId,
            PTProductName = pbuytransaction.PTProductName,
            PTBuyPrice = pbuytransaction.PTBuyPrice,
            PBuyTransactionDate = pbuytransaction.PBuyTransactionDate
        };
    }

    public static POSBuy ToEntity(this UpdatePOSBuyDto pbuytransaction, int PBTId)
    {
        return new POSBuy()
        {
            PBTId = pbuytransaction.PBTId,
            PTVendorName = pbuytransaction.PTVendorName,
            PBTQuantity = pbuytransaction.PBTQuantity,
            PTProductId = pbuytransaction.PTProductId,
            PTProductName = pbuytransaction.PTProductName,
            PTBuyPrice = pbuytransaction.PTBuyPrice,
            PBuyTransactionDate = pbuytransaction.PBuyTransactionDate
            
        };
    }

    public static POSBuyDto ToPOSBuyDto(this POSBuy pbuytransaction)
        {
            return new(
            

                pbuytransaction.PBTId,
                pbuytransaction.PTVendorName,
                pbuytransaction.PBTQuantity,
                pbuytransaction.PTProductId,
                pbuytransaction.PTProductName,
                pbuytransaction.PTBuyPrice,
                pbuytransaction.PBuyTransactionDate
            );
            
            
        }
}