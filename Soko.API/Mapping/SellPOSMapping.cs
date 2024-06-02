using Soko.API.Dtos;
using Soko.API.Entities;

namespace Soko.API.Mapping;

public static class POSSellMapping
{
    public static POSSell ToEntity(this CreatePOSSellDto pselltransaction)
    {
        return new POSSell()
        {
            PSTId = pselltransaction.PSTId,
            PTCustomerName = pselltransaction.PTCustomerName,
            PSTQuantity = pselltransaction.PSTQuantity,
            PTProductId = pselltransaction.PTProductId,
            PTProductName = pselltransaction.PTProductName,
            PTSellPrice = pselltransaction.PTSellPrice,
            PSellTransactionDate = pselltransaction.PSellTransactionDate
        };
    }

    public static POSSell ToEntity(this UpdatePOSSellDto pselltransaction, int PSTId)
    {
        return new POSSell()
        {
            PSTId = pselltransaction.PSTId,
            PTCustomerName = pselltransaction.PTCustomerName,
            PSTQuantity = pselltransaction.PSTQuantity,
            PTProductId = pselltransaction.PTProductId,
            PTProductName = pselltransaction.PTProductName,
            PTSellPrice = pselltransaction.PTSellPrice,
            PSellTransactionDate = pselltransaction.PSellTransactionDate
            
        };
    }

    public static POSSellDto ToPOSSellDto(this POSSell pselltransaction)
        {
            return new(
            

                pselltransaction.PSTId,
                pselltransaction.PTCustomerName,
                pselltransaction.PSTQuantity,
                pselltransaction.PTProductId,
                pselltransaction.PTProductName,
                pselltransaction.PTSellPrice,
                pselltransaction.PSellTransactionDate
            );
            
            
        }
}