using System.Collections.Generic;
using CA.Common.Dto;

namespace CA.Application.Services.Category.Queries.GetAllCategories
{
    public interface IGetAllCategoriesService
    {
        ResultDto<List<AllCategoriesDto>> Execute();
    }
}
