using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoApi3.Data;
using DemoApi3.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApi3.Controllers

{

    [Route("api/[controller]")]

    [ApiController]

    public class EmployeesController : ControllerBase

    {

        private readonly EmployeesContext _context;

        public EmployeesController(EmployeesContext context)

        {

            _context = context;

        }

        // GET: api/<CustomersController>



        [HttpGet]

        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {

            try
            {
                return await _context.Employees.ToListAsync();
            }
            catch(Exception ex)
            {
                return new JsonResult("error" + ex.Message.ToString());
            }            
            //return await _context.Employees.Select(x => Employee(x)).ToListAsync();

        }



        // GET api/<CustomersController>/5

        [HttpGet("{id}")]

        public async Task<ActionResult<Employee>> GetEmployee(int id)

        {

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)

            {

                return NotFound();

            }

            return employee;

        }

        // POST api/<CustomersController>

        [HttpPost]

        public async Task<ActionResult<Employee>> PostEmployees(Employee employee)

        {

            _context.Employees.Add(employee);

            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.Id }, employee);

        }

        // PUT api/<CustomersController>/5

        [HttpPut("{id}")]

        public void Put(int id, [FromBody] string value)

        {

        }

        //Metodo para eliminar /api/products

        [HttpDelete("{id}")]

        public async Task<ActionResult> DeleteEmployee(int id)

        {

            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)

            {

                return NotFound();

            }

            _context.Employees.Remove(employee);

            await _context.SaveChangesAsync();

            return NoContent();

        }

    }

}