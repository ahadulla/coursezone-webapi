using CourseZone.DataAccess.Repositories;
using CourseZone.DataAccsess.Utils;
using CourseZone.Domain.Entites.CourseZonePoints;
using Dapper;

namespace CourseZone.DataAccsess.Interfaces.CourseZonePoints;

public class CourseZonePointRepository : BaseRepository, ICourseZonePointRepository
{
    public async Task<int> CreateCourseZonePointsAsync(CourseZonePoint entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO public.coursezone_point( order_id, price, create_at) " +
                "VALUES (@OrderId, @Price, @CreateAt);";
            return await _connection.ExecuteAsync(query, entity);
        }
        catch
        {
            return 0;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<IList<CourseZonePoint>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"Select *from coursezone_point order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize};";

            return (await _connection.QueryAsync<CourseZonePoint>(query)).ToList();
        }
        catch
        {
            return new List<CourseZonePoint>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
