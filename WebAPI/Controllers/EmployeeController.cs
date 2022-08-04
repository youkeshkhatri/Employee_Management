using Microsoft.AspNetCore.Mvc;
using Sample.Models;
using Sample.Services;
using Services.DbEntity;
using WebAPI.Dtos;
using WebAPI.Factories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IEmployeeFactory _employeeFactory;
        private readonly TaskContext _context;

        public EmployeeController(IEmployeeService employeeService, IEmployeeFactory employeeFactory, TaskContext context)
        {
            _employeeService = employeeService;
            _employeeFactory = employeeFactory;
            _context = context;
        }

        ////BY USING DTO

        // GET: api/<EmployeeController>
        [Route("employees")]
        [HttpGet]
        public async Task<ActionResult<List<SpGetAll>>> GetAll()
        {
            var resp = await _employeeService.GetAllAsync().ConfigureAwait(false);
            //var empDTOs = resp.Select(x => _employeeFactory.MapEmployeeEntityToDTO(x)).ToList();
            return Ok(resp);
        }

        // GET api/<EmployeeController>/5
        [Route("employees/{id}")]
        [HttpGet]
        public async Task<ActionResult<SpGetAll>> DetailsAsync(int? id)
        {
            var resp = await _employeeService.DetailsAsync(id).ConfigureAwait(false);
            //var empDTOs = _employeeFactory.MapEmployeeEntityToDTO(resp);
            return Ok(resp);
        }


        // POST api/<EmployeeController>
        [Route("employees")]
        [HttpPost]
        public async Task<ActionResult<bool>> AddAsync(EmployeeDTO empDTO)
        {
           //var aaa = !_employeeService.FindByIdAsync.Any(e => e.Id == employee.Id);
            var IdExist = _context.Employees.Any(x => x.Id == empDTO.Id);

            if (ModelState.IsValid && empDTO.DateOfBirth < DateTime.Now)
            {
                if(IdExist)
                {
                    return StatusCode(400, "Id is taken");
                }
                var entity = _employeeFactory.MapEmployeeDTOToEntity(empDTO, new Employee());
                await _employeeService.CreateAsync(entity).ConfigureAwait(false);
                return Ok("Created Successfully");
            }
            else
            {
                return BadRequest("Date of Birth can't be in future");
            }
        }

        // PUT api/<EmployeeController>/5
        [Route("employees/{id}")]
        [HttpPut]
        public async Task<ActionResult<bool>> UpdateAsync(EmployeeDTO empDTO)
        {
            var oldData = await _employeeService.FindByIdAsync(empDTO.Id).ConfigureAwait(false);
            var entity = _employeeFactory.MapEmployeeDTOToEntity(empDTO, oldData);
            if (ModelState.IsValid && empDTO.DateOfBirth < DateTime.Now)
            {
                await _employeeService.EditAsync(entity).ConfigureAwait(false);
                return StatusCode(200, "Updated Successfully");
            }
            else
            {
                return StatusCode(400, "Date of Birth can't be in future");
            }
        }

        // DELETE api/<EmployeeController>/5
        [Route("employees/{id}")]
        [HttpDelete]
        public async Task<ActionResult<bool>> RemoveAsync(int id)
        {
            await _employeeService.DeleteAsync(id).ConfigureAwait(false);
            return StatusCode(200, "Deleted Successfully");
        }

        //WITHOUT DTOs

        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Employee>>> GetAllEmployeeAsync()
        //{
        //    var resp = await _employeeService.GetAllAsync().ConfigureAwait(false);
        //    return Ok(resp);
        //}


        //[HttpGet("{id}")]
        //public async Task<Employee> DetailsAsync(int? id)
        //{
        //    return await _employeeService.DetailsAsync(id).ConfigureAwait(false);
        //}

        //[HttpPost]
        //public async Task<bool> AddAsync(Employee employee)
        //{
        //    await _employeeService.CreateAsync(employee).ConfigureAwait(false);
        //    return true;
        //}

        //// PUT api/<EmployeeController>/5
        //[HttpPut("{id}")]
        //public async Task<bool> UpdateAsync(Employee employee)
        //{
        //    await _employeeService.EditAsync(employee).ConfigureAwait(false);
        //    return true;
        //}

        //// DELETE api/<EmployeeController>/5
        //[HttpDelete("{id}")]
        //public async Task<bool> RemoveAsync(int id)
        //{
        //    await _employeeService.DeleteAsync(id).ConfigureAwait(false);
        //    return true;
        //}


    }
}
