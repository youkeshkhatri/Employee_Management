using Sample.Models;
using Services.DbEntity;

namespace Sample.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<List<SpGetAll>> GetAllEmployeeFromProcAsync(int id);   //for api
        Task<List<Employee>> GetAllFromProcAsync(int id);           //for sample/view/index
        //void Update(Employee employee);
    }
}
