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

        public async Task<List<SpGetAll>> GetAllEmployeeFromProcAsync(int id)
        {
            var res = await _context.SpGetAlls
            .FromSqlRaw(String.Format($"EXECUTE sp_GetAllEmployee {id}"))
            //.FromSqlRaw("EXECUTE sp_GetAllEmployee {0}", id)
           // .FromSqlInterpolated($"EXECUTE sp_GetAllEmployee {id}")
            .ToListAsync().ConfigureAwait(false);

            return res;
        }

    }


}
