using CourseZone.DataAccsess.Utils;

namespace CourseZone.DataAccsess.Common.Interfaces;

public interface IGetAll<TModel>
{
    public Task<IList<TModel>> GetAllAsync(PaginationParams @params);
}

