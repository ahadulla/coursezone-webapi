using CourseZone.DataAccsess.Common.Interfaces;
using CourseZone.Domain.Entites.Orders;

namespace CourseZone.DataAccsess.Interfaces.Orders;

public interface IOrderRepository : IRepository<Order, Order>, IGetAll<Order>
{
}
