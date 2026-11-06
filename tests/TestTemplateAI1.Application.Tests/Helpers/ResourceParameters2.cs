using System.Collections.Generic;
using TestTemplateAI1.Application.Sorting.Models;

namespace TestTemplateAI1.Application.Tests.Helpers;

public class ResourceParameters2
    : BaseSortable<MappingSourceModel2>
{
    public override IEnumerable<SortCriteria> SortBy { get; set; } = new List<SortCriteria>();
}
