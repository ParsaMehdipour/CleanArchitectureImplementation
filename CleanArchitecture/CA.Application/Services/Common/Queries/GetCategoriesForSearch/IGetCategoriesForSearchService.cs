using CA.Common.Dto;

namespace CA.Application.Services.Common.Queries.GetCategoriesForSearch
{
    public interface IGetCategoriesForSearchService
    {
        ResultDto<ResultGetCategoriesForSearch> Execute();
    }
}
