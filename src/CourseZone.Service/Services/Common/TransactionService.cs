using CourseZone.DataAccsess.Interfaces.CourseZonePoints;
using CourseZone.DataAccsess.Interfaces.Users;
using CourseZone.Domain.Exceptions.Users;
using CourseZone.Service.Interfaces.Common;

namespace CourseZone.Service.Services.Common;

public class TransactionService : ITransactionService
{
    private IUserRepository _repository;

    public TransactionService(IUserRepository userRepository)
    {
        this._repository = userRepository;
    }
    public async Task<bool> TransactionBuy(long SellerId, long ClientId, double price)
    {
        var seller = await _repository.GetByIdAsync(SellerId);
        if (seller == null) throw new UserNotFoundExcaption();

        var client = await _repository.GetByIdAsync(ClientId);
        if (client == null) throw new UserNotFoundExcaption();

        if(client.Balance > price)
        {
            var result = await _repository.UpdateBalanceAsync(ClientId, client.Balance -  price);
            if (result > 0)
            {
                result = await _repository.UpdateBalanceAsync(SellerId, seller.Balance + (price/100)*90);
                if(result > 0)
                {
                    return true;
                }
                else 
                { 
                    return false; 
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }
}
