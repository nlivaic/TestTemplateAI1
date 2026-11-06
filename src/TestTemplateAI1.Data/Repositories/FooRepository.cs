using TestTemplateAI1.Core.Entities;
using TestTemplateAI1.Core.Interfaces;

namespace TestTemplateAI1.Data.Repositories;

public class FooRepository : Repository<Foo>, IFooRepository
{
    public FooRepository(TestTemplateAI1DbContext context)
        : base(context)
    {
    }
}
