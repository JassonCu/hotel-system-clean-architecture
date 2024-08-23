using System.Data;
using Dapper;
using Hotel.Interface.Interfaces;
using Hotel.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Persistence.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;

        public GenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> ExecAsync(string storeProcedure, object parameter)
        {
            using var connection = _context.Database.GetDbConnection();

            if (connection.State != ConnectionState.Open)
                connection.Open();
            
            var objParam = new DynamicParameters(parameter);
            var recordAffected = await connection.ExecuteAsync(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure);

            return recordAffected > 0;
        }

        public Task<IEnumerable<T>> GetAllAsync(string storeProcedure)
        {
            using var connection = _context.Database.GetDbConnection();

            return connection.QueryAsync<T>(storeProcedure, commandType: CommandType.StoredProcedure);
        }

        public async Task<T> GetByIdAsync(string storeProcedure, object parameter)
        {
            using var connection = _context.Database.GetDbConnection();

            var objParam = new DynamicParameters(parameter);

            return await connection
                .QuerySingleOrDefaultAsync<T>(storeProcedure, param: objParam, commandType: CommandType.StoredProcedure);
        }
    }
}
