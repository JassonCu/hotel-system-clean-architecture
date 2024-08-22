using Dapper;
using Hotel.Domian.Entities;
using Hotel.Interface.Interfaces;
using Hotel.Persistence.Context;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Data;

namespace Hotel.Persistence.Repositories
{
    public class EmployeesRepositories : IEmployeesRepository
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogger<EmployeesRepositories> _logger;


        public EmployeesRepositories(ApplicationDbContext dbContext, ILogger<EmployeesRepositories> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

        public async Task<IEnumerable<Employee>> ListEmployees()
        {
            try
            {
                using var connection = _dbContext.Database.GetDbConnection();

                if (connection.State != ConnectionState.Open)
                {
                    connection.Open();
                }

                var query = "uspEmployeesList";

                var employees = await connection.QueryAsync<Employee>(query, commandType: CommandType.StoredProcedure);

                return employees;
            }
            catch (SqlException sqlEx)
            {
                // Registro de excepciones específicas de SQL
                _logger.LogError(sqlEx, "Error al ejecutar el stored procedure 'uspEmployeesList'");
                throw new ApplicationException("Ocurrió un error al recuperar los empleados. Por favor, intente nuevamente más tarde.");
            }
            catch (Exception ex)
            {
                // Registro de excepciones generales
                _logger.LogError(ex, "Error inesperado en el método ListEmployees");
                throw new ApplicationException("Ocurrió un error inesperado. Por favor, intente nuevamente más tarde.");
            }
        }
    }
}
