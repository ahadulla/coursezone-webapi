using CourseZone.DataAccess.Repositories;
using CourseZone.DataAccsess.Interfaces.Stars;
using CourseZone.Domain.Entites.Stars;
using Dapper;

namespace CourseZone.DataAccsess.Repositories.Stars;

public class StarRepository : BaseRepository, IStarRepository
{
    public async Task<int> CreateAsync(Star entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO stars( user_id, course_id, star) " +
                " VALUES (@UserId, @CourseId, @StarCount);";
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
}
