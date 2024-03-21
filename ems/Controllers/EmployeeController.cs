using ems.Models;
using ems.Models.Service;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ems.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService employeeService;
      

        public EmployeeController(IEmployeeService employeeService ) {
           this.employeeService = employeeService;
         
        }

       

        // GET: api/<EmployeeController>
        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return employeeService.Get();
        }


        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(string id)
        {
            var employee = employeeService.Get(id);
            if (employee == null)
            {
                return NotFound($"employee with  Id = {id} Not Found");
            }
            return employee;
        }



        // POST api/<EmployeeController>
        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {

           employee.UserName = null;
            employeeService.Create(employee);
            return CreatedAtAction(nameof(Get), new { id = employee.EmployeeID }, employee);
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody]  Employee employee)
        {   employee.UserName = null;

            var existingEmployee = employeeService.Get(id);
            if (existingEmployee == null)
            {
                return NotFound($"employee with Id = {id} not found");
            }

            existingEmployee.Update(id, employee);

            return NoContent();
        }


        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {

            var employee = employeeService.Get(id);
            if (employee == null)
            {
                return NotFound($"employee with Id = {id} not found");
            }
            employeeService.Remove(employee.EmployeeID);

            return Ok($"user with id = {id} deleted");
        }
    }
}
