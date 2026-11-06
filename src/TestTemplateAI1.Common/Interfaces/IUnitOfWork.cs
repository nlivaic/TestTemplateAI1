using System.Threading.Tasks;

namespace TestTemplateAI1.Common.Interfaces;

public interface IUnitOfWork
{
    Task<int> SaveAsync();
}