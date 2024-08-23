using Hotel.Domian.Entities;
using Hotel.Interface.Interfaces;

namespace Hotel.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IGenericRepository<Employee> Employee { get; }

        public UnitOfWork(IGenericRepository<Employee> employee)
        {
            Employee = employee;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
