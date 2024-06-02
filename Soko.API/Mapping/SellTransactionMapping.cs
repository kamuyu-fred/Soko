using Soko.API.Dtos;
using Soko.API.Entities;

namespace Soko.API.Mapping;

public static class SellTransactionMapping
{
    public static SellTransaction ToEntity(this CreateSellTransactionDto selltransaction)
    {
        return new SellTransaction()
        {
            STId = selltransaction.STId,
            TCustomerName = selltransaction.TCustomerName,
            STQuantity = selltransaction.STQuantity,
            TProductId = selltransaction.TProductId,
            TProductName = selltransaction.TProductName,
            TSellPrice = selltransaction.TSellPrice,
            SellTransactionDate = selltransaction.SellTransactionDate
        };
    }

    public static SellTransaction ToEntity(this UpdateSellTransactionDto selltransaction, int STId)
    {
        return new SellTransaction()
        {
            STId = selltransaction.STId,
            TCustomerName = selltransaction.TCustomerName,
            STQuantity = selltransaction.STQuantity,
            TProductId = selltransaction.TProductId,
            TProductName = selltransaction.TProductName,
            TSellPrice = selltransaction.TBuyPrice,
            SellTransactionDate = selltransaction.SellTransactionDate
            
        };
    }

    public static SellTransactionDto ToSellTransactionDto(this SellTransaction selltransaction)
        {
            return new(
            

                selltransaction.STId,
                selltransaction.TCustomerName,
                selltransaction.STQuantity,
                selltransaction.TProductId,
                selltransaction.TProductName,
                selltransaction.TSellPrice,
                selltransaction.SellTransactionDate
            );
            
            
        }
}