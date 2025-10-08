using EmployeePortal.Data;
using EmployeePortal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Services
{
    public class EmployeeService
    {
        private readonly ApplicationDbContext _context;
        public EmployeeService(ApplicationDbContext dbContext)
        {
            this._context = dbContext;
        }
        public async Task<List<Employee>> GetAll()
        {
            return await _context.Employees.ToListAsync();
        }
        public async Task<Employee> GetById(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return null!;
            return employee;
        }
        public async Task<Employee> Create(Employee employee)
        {
            employee.Id = Guid.NewGuid();
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();
            return employee;
        }

        public async Task<Employee> Update(Guid id, Employee employee)
        {
            if (id != employee.Id) return null!;

            _context.Entry(employee).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await _context.Employees.AnyAsync(e => e.Id == id))
                    return null!;
                throw;
            }

            return employee;
        }
        public async Task<Employee> Delete(Guid id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if (employee == null) return null!;

            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();

            return employee;
        }
    }
}
