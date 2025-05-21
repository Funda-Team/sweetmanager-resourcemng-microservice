namespace ResourceMngService.Shared.Domain.Repositories
{
    public interface IUnitOfWork
    {
        Task CommitAsync();
    }
}
