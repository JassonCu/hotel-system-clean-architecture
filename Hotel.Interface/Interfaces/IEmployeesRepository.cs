using Hotel.Domian.Entities;

namespace Hotel.Interface.Interfaces
{
    public interface IEmployeesRepository
    {
        Task<IEnumerable<Employee>> ListEmployees();
    }
}
