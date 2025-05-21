using IamService.Shared.Domain.Repositories;

namespace ResourceMngService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork(ResourceMngContext context) : IUnitOfWork
    {
        public async Task CommitAsync() => await context.SaveChangesAsync();
    }
}