using EmployeePortal.Data;
using EmployeePortal.Models;
using EmployeePortal.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly  EmployeeService employerService;
        public EmployeesController(EmployeeService _employerService)
        {
            this.employerService = _employerService;
        }

        // GET: api/employees
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAll()
        {
            return await employerService.GetAll();
        }

        // GET: api/employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(Guid id)
        {
            var employee = await employerService.GetById(id);
            if (employee == null) return NotFound();
            return employee;
        }

        // POST: api/employees
        [HttpPost]
        public async Task<ActionResult<Employee>> Create(Employee employee)
        {
            return await employerService.Create(employee);
        }

        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, Employee employee)
        {
            if (id != employee.Id) return BadRequest();
            Employee emp= await employerService.Update(id,employee);
            if(emp!=null) return Ok(emp);  
            return NoContent();
        }

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            var employee = await employerService.Delete(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }
    }
}
