using AutoMapper;
using Sample.Models;
using WebAPI.Dtos;

namespace WebAPI.Factories
{
    public class EmployeeFactory : IEmployeeFactory
    {
        private readonly IMapper _mapper;

        public EmployeeFactory(IMapper mapper)
        {
            _mapper = mapper;
        }

        public EmployeeDTO MapEmployeeEntityToDTO(Employee entity)
        {
            return _mapper.Map<EmployeeDTO>(entity); //using automapper
        }

        public List<EmployeeDTO> MapEntitytoDTO(List<Employee>? emp)
        {
            if (emp == null)
                return new List<EmployeeDTO>();


            var studentDtos = emp.Select(x => new EmployeeDTO  
            {
                Name = x.Name,
                Position = x.Position,
                Address = x.Address

            }).ToList();
            return studentDtos;

        }


        public Employee MapEmployeeDTOToEntity( EmployeeDTO dto, Employee entity)
        {
            entity.Id = dto.Id;
            entity.Name = dto.Name;
            entity.Position = dto.Position; 
            entity.Address = dto.Address;
            entity.Email = dto.Email;
            entity.DateOfBirth = dto.DateOfBirth;

            return entity;
        }
    }
}
