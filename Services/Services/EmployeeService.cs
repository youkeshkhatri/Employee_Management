using Sample.Models;
using Sample.Repository;
using Services.DbEntity;
using Services.UOW;

namespace Sample.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IUnitOfWork _uow;

        public EmployeeService(IEmployeeRepository employeeRepository, IUnitOfWork uow)
        {
            _employeeRepository = employeeRepository;
            _uow = uow;
        }



        public async Task<Employee> FindByIdAsync(int id)
        {
            return await _employeeRepository.GetByIdAsync(id).ConfigureAwait(false);
            //var resp = await _employeeRepository.GetAllEmployeeFromProcAsync(id).ConfigureAwait(false);
            //return resp.First();
        }

        public async Task<SpGetAll> DetailsAsync(int? id)
        {
            var resp = await _employeeRepository.GetAllEmployeeFromProcAsync(id.Value).ConfigureAwait(false);
            return resp.First();
        }

        public async Task<List<SpGetAll>> GetAllAsync()
        {
            //var resp = await _employeeRepository.FromSqlRaw("exec sp_GetAllEmployee");
            var res= await _employeeRepository.GetAllEmployeeFromProcAsync(-1).ConfigureAwait(false);
            return res;
        }

        public async Task<bool> CreateAsync(Employee employee)
        {
            
            employee.CreatedBy = Guid.NewGuid();
            employee.CreatedOn = DateTime.Now;
            await _employeeRepository.AddAsync(employee).ConfigureAwait(false);
            _uow.CommitChanges();
            return true;
        }

        public Task<bool> EditAsync(Employee employee)
        {
            employee.ModifiedBy = Guid.NewGuid();
            employee.ModifiedOn = DateTime.Now;
            _employeeRepository.Update(employee);
            _uow.CommitChanges();
            return Task.FromResult(true);
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var employee = await FindByIdAsync(id).ConfigureAwait(false);
            employee.IsDeleted = true;
            employee.DeletedBy = Guid.NewGuid();
            employee.DeletedOn = DateTime.Now;
            _employeeRepository.Update(employee);
            //_employeeRepository.Remove(employee);
            _uow.CommitChanges();
            return true;
        }

    }
}

