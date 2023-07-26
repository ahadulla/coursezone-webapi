using CourseZone.DataAccsess.Utils;
using CourseZone.Domain.Entites.Orders;
using CourseZone.Service.Dtos.Order;

namespace CourseZone.Service.Interfaces.Orders;

public interface IOrderService
{
    public Task<bool> CreateAsync(OrderCreateDto dto);

    public Task<IList<Order>> GetAllAsync(PaginationParams @params);
}
