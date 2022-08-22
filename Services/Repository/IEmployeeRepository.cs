using Sample.Models;
using Services.DbEntity;

namespace Sample.Repository
{
    public interface IEmployeeRepository : IGenericRepository<Employee>
    {
        Task<List<SpGetAll>> GetAllEmployeeFromProcAsync(int id); 
    }
}
