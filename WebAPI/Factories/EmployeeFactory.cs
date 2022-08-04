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
            return _mapper.Map<EmployeeDTO>(entity);
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
