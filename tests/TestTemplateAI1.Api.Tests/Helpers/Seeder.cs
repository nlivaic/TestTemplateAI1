using System.Collections.Generic;
using TestTemplateAI1.Core.Entities;
using TestTemplateAI1.Data;

namespace TestTemplateAI1.Api.Tests.Helpers;

public static class Seeder
{
    public static void Seed(this TestTemplateAI1DbContext ctx)
    {
        ctx.Foos.AddRange(
            new List<Foo>
            {
                new ("Text 1"),
                new ("Text 2"),
                new ("Text 3")
            });
        ctx.SaveChanges();
    }
}
