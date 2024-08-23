using Hotel.Domian.Entities;

namespace Hotel.Interface.Interfaces;

public interface IUnitOfWork
{
    IGenericRepository<Employee> Employee { get; }
}
