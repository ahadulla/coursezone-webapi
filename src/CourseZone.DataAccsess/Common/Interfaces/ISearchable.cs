using CourseZone.DataAccsess.Utils;

namespace CourseZone.DataAccsess.Common.Interfaces;

public interface ISearchable<TModel>
{
    public Task<(int ItemsCount, IList<TModel>)> SearchAsync(string search,
        PaginationParams @params);
}
