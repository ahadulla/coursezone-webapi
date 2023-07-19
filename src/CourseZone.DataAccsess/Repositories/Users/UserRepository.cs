using CourseZone.DataAccess.Repositories;
using CourseZone.DataAccsess.Interfaces.Users;
using CourseZone.DataAccsess.Utils;
using CourseZone.Domain.Entites.Users;
using Dapper;

namespace CourseZone.DataAccsess.Repositories.Users;

public class UserRepository : BaseRepository, IUserRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT count(*) from users";
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

    public async Task<int> CreateAsync(User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO users( first_name, last_name, email, phone_number, balance, avatar_path, password_hash, salt, created_at, updated_at, is_delated) " +
                "VALUES(@FirstName, @LastName, @Email, @PhoneNumber, @Balance, @AvatarPath, @PasswordHash, @Salt, @CreatedAt, @UpdatedAt, @IsDetated); ";
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
            string query = $"delete from users where id = @Id";
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

    public async Task<IList<User>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from companies " +
                $"order by id desc " +
                $"offset {@params.GetSkipCount()} limit {@params.PageSize}";
            var result = (await _connection.QueryAsync<User>(query)).ToList();
            return result;
        }
        catch
        {
            return new List<User>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }

    public async Task<User?> GetByIdAsync(long id)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select * from users where id = {id}";
            var result = await _connection.QuerySingleAsync<User>(query);
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

    public Task<(int ItemsCount, IList<User>)> SearchAsync(string search, PaginationParams @params)
    {
        throw new NotImplementedException();
    }

    public async Task<int> UpdateAsync(long id, User entity)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "UPDATE users " +
                "SET first_name=@FirstName, last_name=@LastName, email=@Email, phone_number=@PhoneNumber, " +
                "balance=@Balance, avatar_path=@AvatarPath, password_hash=@PasswordHash, salt=@Salt, " +
                "created_at=@CreatedAt, updated_at=@UpdatedAt, is_delated=@IsDetated " +
                $"WHERE id = {id};";
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
