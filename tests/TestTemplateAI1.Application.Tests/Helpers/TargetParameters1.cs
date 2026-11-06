using System.Collections.Generic;
using TestTemplateAI1.Application.Sorting.Models;

namespace TestTemplateAI1.Application.Tests.Helpers;

public class TargetParameters1
    : BaseSortable<MappingTargetModel1>
{
    public override IEnumerable<SortCriteria> SortBy { get; set; } = new List<SortCriteria>();
}
