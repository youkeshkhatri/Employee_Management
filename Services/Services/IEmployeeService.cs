using Sample.Models;
using Services.DbEntity;

namespace Sample.Services
{
    public interface IEmployeeService
    {
        Task<Employee> FindByIdAsync(int id);

        Task<bool> DeleteAsync(int id);

        Task<bool> CreateAsync(Employee employee);

        Task<bool> EditAsync(Employee employee);

        Task<SpGetAll> DetailsAsync(int? id);

        Task<List<SpGetAll>> GetAllAsync();

        //for sample index
        Task<List<Employee>> GetAllEmpAsync();
        Task<Employee> EmpDetailsAsync(int? id);

    }
}
