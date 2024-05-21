using Soko.API.Dtos;
using Soko.API.Entities;

namespace Soko.API.Mapping;

public static class BuyTransactionMapping
{
    public static BuyTransaction ToEntity(this CreateBuyTransactionDto buytransaction)
    {
        return new BuyTransaction()
        {
            BTId = buytransaction.BTId,
            TVendorName = buytransaction.TVendorName,
            TQuantity = buytransaction.TQuantity,
            TProductId = buytransaction.TProductId,
            TProductName = buytransaction.TProductName,
            TBuyPrice = buytransaction.TBuyPrice,
            BuyTransactionDate = buytransaction.BuyTransactionDate
        };
    }

    public static BuyTransactionDto ToBuyTransactionDto(this BuyTransaction buytransaction)
        {
            return new(
            

                buytransaction.BTId,
                buytransaction.TVendorName,
                buytransaction.TQuantity,
                buytransaction.TProductId,
                buytransaction.TProductName,
                buytransaction.TBuyPrice,
                buytransaction.BuyTransactionDate
            );
            
            
        }
}