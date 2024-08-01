using Dapper;
using Hotel.Domian.Entities;
using Hotel.Interface.Interfaces;
using Hotel.Persistence.Context;
using System.Data;

namespace Hotel.Persistence.Repositories
{
    public class EmployeesRepositories : IEmployeesRepository
    {
        private readonly ApplicationDBContext _dbContext;

        public EmployeesRepositories(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Employees>> ListEmployees()
        {
            using var connection = _dbContext.CreateConnection;

            var query = "uspEmployeesList";

            var employees = await connection.QueryAsync<Employees>(query, commandType: CommandType.StoredProcedure);

            return employees;
        }
    }
}
