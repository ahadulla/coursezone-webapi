using CourseZone.DataAccess.Repositories;
using CourseZone.DataAccsess.Interfaces.Videos;
using CourseZone.DataAccsess.Utils;
using CourseZone.Domain.Entites.Users;
using CourseZone.Domain.Entites.Videas;
using Dapper;

namespace CourseZone.DataAccsess.Repositories.Videos;

public class VideosRepository : BaseRepository, IVideoRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT count(*) from videos";
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

    public async Task<int> CreateAsync(Video entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO videos ( name, course_id, description, video_path, image_path, created_at, updated_at) " +
                "VALUES (@Name, @CourseId, @Description, @VideoPath,@ImagePath, @CreatedAt, @UpdatedAt);";
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
            string query = $"delete from videos where id = @Id";
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

    public async Task<IList<Video>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from videos " +
                $"order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<Video>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<Video>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<Video?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from videos where id = {id}";
            var result = await _connection.QuerySingleAsync<Video>(query);
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

    public async Task<(int ItemsCount, IList<Video>)> SearchAsync(string search, PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "select *from videos where name ilike '%@Search%' order by id desc " +
                        $" offset {@params.GetSkipCount()} limit {@params.PageSize};";
            var result = (await _connection.QueryAsync<Video>(query, new { Search = search })).ToList();

            return (result.Count(), result);
        }
        catch
        {
            return (0, new List<Video>());
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<int> UpdateAsync(long id, Video entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE videos SET  " +
                " name = @Name, course_id = @CourseId, description = @Description, video_path = @VideoPath, image_path = @ImagePath, updated_at = @UpdatedAt " +
                $" WHERE id={id};";
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
