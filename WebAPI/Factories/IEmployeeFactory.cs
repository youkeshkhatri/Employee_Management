using Sample.Models;
using Services.DbEntity;
using WebAPI.Dtos;

namespace WebAPI.Factories
{
    public interface IEmployeeFactory
    {
        EmployeeDTO MapEmployeeEntityToDTO(Employee entity);

        Employee MapEmployeeDTOToEntity(EmployeeDTO dto, Employee entity);
    }
}
