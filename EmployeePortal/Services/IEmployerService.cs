using EmployeePortal.Models;
using System.Xml;

namespace EmployeePortal.Services
{
    public interface IEmployerService
    {
        Task<IEnumerable<Employee>> GetAll();
        Task<Employee> GetById(Guid id);
        Task Create(Employee entity);
        Task Update(Employee entity);
        Task Delete(Guid id);
    }
}
