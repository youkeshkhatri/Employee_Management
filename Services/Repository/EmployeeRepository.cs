using Microsoft.EntityFrameworkCore;
using Sample.Models;
using Services.DbEntity;

namespace Sample.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(TaskContext context) : base(context)
        {

        }

        //retriving from Procdure model
        public async Task<List<SpGetAll>> GetAllEmployeeFromProcAsync(int id)
        {
            return await _context.SpGetAlls
            .FromSqlRaw(String.Format("EXECUTE sp_GetAllEmployee {0}", id))
          //.FromSqlInterpolated($"EXECUTE sp_GetAllEmployee {id}")
            .ToListAsync().ConfigureAwait(false);
        }



        //retriving from employee model
        public async Task<List<Employee>> GetAllFromProcAsync(int id)
        {
            return await _context.Employees
            .FromSqlRaw(String.Format("EXECUTE sp_GetAllEmployee {0}", id))
            .ToListAsync().ConfigureAwait(false);
        }
    }


}
