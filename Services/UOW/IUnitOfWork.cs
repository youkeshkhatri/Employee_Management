namespace Services.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        //IEmployeeRepository Employees { get; }
        int CommitChanges();
    }
}
