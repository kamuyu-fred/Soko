using Soko.API.Dtos;
using Soko.API.Entities;


namespace Soko.API.Mapping;

public static class BuyTransactionMapping
{
    public static BuyTransaction ToEntity(this BuyTransactionDto buytransaction)
    {
        return new BuyTransaction()
        {
            TProductId = buytransaction.TProductId,
            TQuantity = buytransaction.TQuantity,
            TProductName = buytransaction.TProductName,
            TBuyPrice = buytransaction.TBuyPrice,
            BuyTransactionDate = buytransaction.BuyTransactionDate


        };
    }
}