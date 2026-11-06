using System.Collections.Generic;
using TestTemplateAI1.Application.Sorting.Models;

namespace TestTemplateAI1.Application.Sorting;

public interface IPropertyMappingService
{
    IEnumerable<SortCriteria> Resolve(BaseSortable sortableSource, BaseSortable sortableTarget);
}
