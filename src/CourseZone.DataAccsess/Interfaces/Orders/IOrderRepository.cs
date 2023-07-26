using CourseZone.DataAccsess.Common.Interfaces;
using CourseZone.Domain.Entites.Orders;

namespace CourseZone.DataAccsess.Interfaces.Orders;

public interface IOrderRepository : IGetAll<Order>
{
    public Task<long> CreateAsync(Order order);

    public Task<long> CountAsync();
}
