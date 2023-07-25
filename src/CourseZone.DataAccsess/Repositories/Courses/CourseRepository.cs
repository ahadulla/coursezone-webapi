using CourseZone.DataAccess.Repositories;
using CourseZone.DataAccsess.Interfaces.Courses;
using CourseZone.DataAccsess.Utils;
using CourseZone.DataAccsess.ViewModels.Courses;
using CourseZone.Domain.Entites.Courses;
using Dapper;

namespace CourseZone.DataAccsess.Repositories.Courses;

public class CourseRepository : BaseRepository, ICourseRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from course";
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

    public async Task<int> CreateAsync(Course entity)
    {
        try
        {
            await _connection.OpenAsync();

            string query = "INSERT INTO public.course( language, user_id, course_type_id, name, price, description, image_path, created_at, updated_at) " +
                "VALUES (@Language, @UserId, @CoursetypeId, @Name, @Price, @Description, @ImagePath, @CreatedAt, @UpdatedAt);";

            return await _connection.ExecuteAsync(query,entity);

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

            string query = "DELETE FROM course WHERE id=@Id";

            return await _connection.ExecuteAsync(query, new {Id = id});
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

    public async Task<IList<CourseViewModel>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT course.id, course.language, users.first_name || ' ' ||users.last_name as creator, " +
                " course_type.name as \"type\", course.name, course.price, course.description, course.image_path, " +
                " course.created_at, course.updated_at FROM course join users on users.id = course.user_id " +
                " join course_type on course_type.id = course.course_type_id order by id desc " +
                $" offset {@params.GetSkipCount()} limit {@params.PageSize}";

            var result = (await _connection.QueryAsync<CourseViewModel>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<CourseViewModel>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<CourseViewModel?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT course.id, course.language, users.first_name || ' ' ||users.last_name as creator, " +
                " course_type.name as \"type\", course.name, course.price, course.description, course.image_path, " +
                " course.created_at, course.updated_at FROM course join users on users.id = course.user_id " +
                " join course_type on course_type.id = course.course_type_id where id=@Id ";

            var result = await _connection.QuerySingleAsync<CourseViewModel>(query, new {Id = id});
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

    public async Task<Course?> GetByIdAsyncSpecial(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "SELECT * FROM course WHERE id=Id;";

            return await _connection.QuerySingleAsync<Course>(query, new {Id = id});
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

    public Task<(int ItemsCount, IList<CourseViewModel>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, Course entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE course SET language=@Language, user_id=@UserId, course_type_id=@CourseTypeId, " +
                "name=@Name, price=@Price, description=@Description, image_path=@ImagePath, updated_at=@UpdatedAt " +
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
