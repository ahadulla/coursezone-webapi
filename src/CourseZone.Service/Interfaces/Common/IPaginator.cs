using CourseZone.DataAccsess.Utils;

namespace CourseZone.Service.Interfaces.Common;

public interface IPaginator
{
    public void Paginate(long itemsCount, PaginationParams @params);
}
