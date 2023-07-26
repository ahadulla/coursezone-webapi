using CourseZone.DataAccess.Repositories;
using CourseZone.DataAccsess.Interfaces.Courses;
using CourseZone.DataAccsess.Utils;
using CourseZone.Domain.Entites.Courses;
using Dapper;

namespace CourseZone.DataAccsess.Repositories.Courses;

public class CourseTypeRepository : BaseRepository, ICourseTypeRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from course_type";
            var result = await _connection.QuerySingleAsync<long>(query);
            return result;
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

    public async Task<int> CreateAsync(CourseType entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO course_type(name, description, image_path, created_at, updated_at) " +
                "VALUES (@Name, @Description, @ImagePath, @CreatedAt, @UpdatedAt);";
            var result = await _connection.ExecuteAsync(query, entity);
            return result;
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

    public async Task<int> DeleteAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "DELETE FROM course_type WHERE id=@Id";
            var result = await _connection.ExecuteAsync(query, new { Id = id });
            return result;
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

    public async Task<IList<CourseType>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM course_type order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<CourseType>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<CourseType>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<CourseType?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM course_type where id=@Id";
            var result = await _connection.QuerySingleAsync<CourseType>(query, new { Id = id });
            return result;
        }
        catch
        {
            return null;
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, CourseType entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"UPDATE course_type " +
                $"SET name=@Name, description=@Description, image_path=@ImagePath, created_at=@CreatedAt, updated_at=@UpdatedAt " +
                $"WHERE id={id};";

            var result = await _connection.ExecuteAsync(query, entity);
            return result;
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
