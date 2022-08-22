using Microsoft.AspNetCore.Mvc;
using Sample.Models;
using Sample.Services;
using Services.DbEntity;
using WebAPI.Dtos;
using WebAPI.Factories;


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
           // var empDTOs = resp.Select(x => _employeeFactory.MapEmployeeEntityToDTO(x)).ToList();
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
            var IdExist = _context.Employees.Any(x => x.Id == empDTO.Id);

            if (ModelState.IsValid && empDTO.DateOfBirth < DateTime.Now)
            {
                if(IdExist)
                {
                    return StatusCode(404, "Id is taken");
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

    }
}
