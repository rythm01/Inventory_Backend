using Microsoft.EntityFrameworkCore;
namespace WebAppRepo.UnitofWork
{
    public interface IUnitOfWork : IDisposable
    {
        DbContext Context { get; }
        public Task SaveChangesAsync();
    }
}
