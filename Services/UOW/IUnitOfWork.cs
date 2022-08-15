namespace Services.UOW
{
    public interface IUnitOfWork : IDisposable
    {
        int CommitChanges();
    }
}
