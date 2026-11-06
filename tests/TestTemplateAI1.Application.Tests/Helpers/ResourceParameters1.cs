using System.Collections.Generic;
using TestTemplateAI1.Application.Sorting.Models;

namespace TestTemplateAI1.Application.Tests.Helpers;

public class ResourceParameters1
    : BaseSortable<MappingSourceModel1>
{
    public override IEnumerable<SortCriteria> SortBy { get; set; } = new List<SortCriteria>();
}
