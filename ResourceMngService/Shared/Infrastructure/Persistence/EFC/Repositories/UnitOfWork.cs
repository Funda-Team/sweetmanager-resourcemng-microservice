using ResourceMngService.Shared.Domain.Repositories;
using ResourceMngService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ResourceMngService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork(ResourcemngContext context) : IUnitOfWork
    {
        public async Task CommitAsync() => await context.SaveChangesAsync();
    }
}