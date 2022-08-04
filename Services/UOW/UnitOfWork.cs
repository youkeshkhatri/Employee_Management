using Sample.Models;
using Services.UOW;

namespace Sample.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TaskContext _context;
        public UnitOfWork(TaskContext context)
        {
            _context = context;
            //Employees = new EmployeeRepository(_context);
        }
        //public IEmployeeRepository Employees { get; private set; }

        public int CommitChanges()
        {
            return _context.SaveChanges();
        }
        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
