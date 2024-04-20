namespace EPuna.DAL.IRepositories
{
    public interface IUnitOfWork
    {
        Task SaveChanges();
    }
}