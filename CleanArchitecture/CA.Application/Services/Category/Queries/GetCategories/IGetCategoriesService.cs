using System.Collections.Generic;
using CA.Common.Dto;

namespace CA.Application.Services.Category.Queries.GetCategories
{
    public interface IGetCategoriesService
    {
        ResultDto<List<CategoriesDto>> Execute(long? ParentId);
    }
}



