namespace CourseZone.Service.Interfaces.Common;

public interface ITransactionService
{
    public Task<bool> TransactionBuy(long SellerId, long ClientId, double price);
}
