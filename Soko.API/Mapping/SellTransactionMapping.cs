using Soko.API.Dtos;
using Soko.API.Entities;


namespace Soko.API.Mapping;

public static class SellTransactionMapping
{
    public static SellTransaction ToEntity(this SellTransactionDto selltransaction)
    {
        return new SellTransaction()
        {
            TProductId = selltransaction.TProductId,
            TQuantity = selltransaction.TQuantity,
            TProductName = selltransaction.TProductName,
            TSellPrice = selltransaction.TSellPrice,
            SellTransactionDate = selltransaction.SellTransactionDate


        };
    }
}