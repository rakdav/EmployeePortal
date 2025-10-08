using EmployeePortal.Data;
using EmployeePortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EmployeePortal.Services
{
    public class EmployeeService : IEmployerService
    {
        private readonly ApplicationDbContext context;
        public EmployeeService(ApplicationDbContext _context)
        {
            this.context = _context;
        }
        public async Task<IEnumerable<Employee>> GetAll()
        {
            return await context.Employees.ToListAsync();
        }
        public async Task<Employee> GetById(Guid id)
        {
            return await context.Employees.FindAsync(id);
        }
        public async Task Create(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            context.Employees.Add(employee);
            await context.SaveChangesAsync();
        }

        public async Task Update(Employee employee)
        {

            context.Entry(employee).State = EntityState.Modified;
            context.Employees.Update(employee);
            await context.SaveChangesAsync();
       
        }
        public async Task Delete(Guid id)
        {
            var employee = await context.Employees.FindAsync(id);
            if (employee != null)
            {
                context.Employees.Remove(employee);
                await context.SaveChangesAsync();
            }
        }
    }
}
