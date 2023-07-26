using CourseZone.DataAccess.Repositories;
using CourseZone.DataAccsess.Interfaces.Orders;
using CourseZone.DataAccsess.Utils;
using CourseZone.Domain.Entites.Orders;
using Dapper;

namespace CourseZone.DataAccsess.Repositories.Orders;

public class OrderRepository : BaseRepository, IOrderRepository
{
    public async Task<long> CountAsync()
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"select count(*) from orders";
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

    public async Task<long> CreateAsync(Order order)
    {
        try
        {
            await _connection.OpenAsync();
            string query = "INSERT INTO orders( user_id, course_id, create_at) " +
                "VALUES (@UserId, @CourseId, @CreateAt) RETURNING id;";
            return await _connection.ExecuteScalarAsync<long>(query, order);
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

    public async Task<IList<Order>> GetAllAsync(PaginationParams @params)
    {
        try
        {
            await _connection.OpenAsync();
            string query = $"SELECT * FROM orders order by id desc offset {@params.GetSkipCount()} limit {@params.PageSize} ;";
            return (await _connection.QueryAsync<Order>(query)).ToList();
        }
        catch
        {
            return new List<Order>();
        }
        finally
        {
            await _connection.CloseAsync();
        }
    }
}
