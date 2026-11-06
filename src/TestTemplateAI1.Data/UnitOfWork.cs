using System.Threading.Tasks;
using TestTemplateAI1.Common.Interfaces;

namespace TestTemplateAI1.Data;

public class UnitOfWork : IUnitOfWork
{
    private readonly TestTemplateAI1DbContext _dbContext;

    public UnitOfWork(TestTemplateAI1DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<int> SaveAsync()
    {
        if (_dbContext.ChangeTracker.HasChanges())
        {
            return await _dbContext.SaveChangesAsync();
        }
        return 0;
    }
}