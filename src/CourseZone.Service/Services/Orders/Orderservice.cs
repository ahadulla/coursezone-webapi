using CourseZone.DataAccsess.Interfaces.Courses;
using CourseZone.DataAccsess.Interfaces.CourseZonePoints;
using CourseZone.DataAccsess.Interfaces.Orders;
using CourseZone.DataAccsess.Utils;
using CourseZone.Domain.Entites.CourseZonePoints;
using CourseZone.Domain.Entites.Orders;
using CourseZone.Service.Common.Helpers;
using CourseZone.Service.Dtos.Order;
using CourseZone.Service.Interfaces.Common;
using CourseZone.Service.Interfaces.Orders;

namespace CourseZone.Service.Services.Orders;

public class Orderservice : IOrderService
{
    private IOrderRepository _repository;
    private IPaginator _paginator;
    private ICourseRepository _courseRepository;
    private ICourseZonePointRepository _courseZonePointRepository;
    private ITransactionService _transactionService;

    public Orderservice(IOrderRepository orderRepository, IPaginator paginator,
        ICourseRepository courseRepository, ICourseZonePointRepository courseZonePointRepository,
        ITransactionService transactionService)
    {
        this._repository = orderRepository;
        this._paginator = paginator;
        this._courseRepository = courseRepository;
        this._courseZonePointRepository = courseZonePointRepository;
        this._transactionService = transactionService;
    }
    public async Task<bool> CreateAsync(OrderCreateDto dto)
    {
        Order order = new Order();
        order.UserId = dto.UserId;
        order.CourseId = dto.CourseId;
        order.CreateAt = TimeHelper.GetDateTime();
        var result = await _repository.CreateAsync(order);
        var course = await _courseRepository.GetByIdAsyncSpecial(dto.CourseId);
        if (course is not null)
        {
            var check = await _transactionService.TransactionBuy(course.UserId, dto.UserId, course.Price);
            CourseZonePoint courseZonePoint = new CourseZonePoint();
            courseZonePoint.OrderId = result;
            courseZonePoint.Price = (course.Price / 100) * 10;
            courseZonePoint.CreateAt = TimeHelper.GetDateTime();
            result = await _courseZonePointRepository.CreateCourseZonePointsAsync(courseZonePoint);

            if (check && result > 0)
            {
                return true;
            }
            else
                return false;
        }
        return false;
    }

    public async Task<IList<Order>> GetAllAsync(PaginationParams @params)
    {
        var orders = await _repository.GetAllAsync(@params);
        var count = await _repository.CountAsync();
        _paginator.Paginate(count, @params);
        return orders;
    }
}
