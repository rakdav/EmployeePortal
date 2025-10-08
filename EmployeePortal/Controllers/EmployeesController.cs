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
        public async Task<ActionResult<IEnumerable<Employee>>> GetAll()
        {
            var employers= await employerService.GetAll();
            return Ok(employers);
        }

        // GET: api/employees/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(Guid id)
        {
            var employee = await employerService.GetById(id);
            if (employee == null) return NotFound();
            return Ok(employee);
        }

        // POST: api/employees
        [HttpPost]
        public async Task<ActionResult<Employee>> Create([FromBody]Employee employee)
        {
            await employerService.Create(employee);
            return CreatedAtAction(nameof(GetById), new { id = employee.Id }, employee);

        }

        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id,[FromBody] Employee employee)
        {
            if (id != employee.Id) return BadRequest();
            await employerService.Update(employee);
            return NoContent();
        }

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await employerService.Delete(id);
            return NoContent();
        }
    }
}
