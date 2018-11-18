using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Dapper;
using KP.Infrastructure.Connections;

namespace KP.Domain.Contracts
{
    public class BaseRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public BaseRepository(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;
        }

        protected async Task<TEntity> QueryFirstOrDefault<TEntity>(string sql, object param = null)
        {
            return (await Query<TEntity>(sql, param)).FirstOrDefault();
        }

        protected async Task<TEntity> QuerySingle<TEntity>(string sql, object param = null)
        {
            return (await Query<TEntity>(sql, param)).SingleOrDefault();
        }

        protected async Task<IEnumerable<TEntity>> Query<TEntity>(string sql, object param = null, CommandType? commandType = null)
        {
            try
            {
                using (var connection = _connectionFactory.Get())
                    return await connection.QueryAsync<TEntity>(sql, param, null, null, commandType);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return null;
        }

        protected async Task<bool> Execute(string sql, object param, CommandType? commandType)
        {
            using (var connection = _connectionFactory.Get())
                return await connection.ExecuteAsync(sql, param, null, null, commandType) > 0;
        }

        protected async Task<bool> ExecuteTran(string sql, object param, CommandType? commandType)
        {
            using (var connection = _connectionFactory.Get())
            {
                var trans = connection.BeginTransaction();
                return await connection.ExecuteAsync(sql, param, trans, null, commandType) > 0;
            }
        }

        protected async Task<TEntity> QuerySingleSp<TEntity>(string sql, object param, CommandType? commandType)
        {
            return (await QuerySp<TEntity>(sql, param, commandType)).SingleOrDefault();
        }

        protected async Task<IEnumerable<TEntity>> QuerySp<TEntity>(string sql, object param, CommandType? commandType)
        {
            using (var connection = _connectionFactory.Get())
                return await connection.QueryAsync<TEntity>(sql, param, null, null, commandType);
        }

        protected async Task<IEnumerable<TReturn>> QueryMulti<TFirst, TSecond, TReturn>(string sql,
            Func<TFirst, TSecond, TReturn> map, CommandType? commandType = null)
        {
            using (var connection = _connectionFactory.Get())
                return await connection.QueryAsync(sql, map, commandType);
        }
    }
}
