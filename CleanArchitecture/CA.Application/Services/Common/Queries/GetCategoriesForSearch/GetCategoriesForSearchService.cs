using System.Linq;
using CA.Application.Interfaces.Contexts;
using CA.Common.Dto;

namespace CA.Application.Services.Common.Queries.GetCategoriesForSearch
{
    public class GetCategoriesForSearchService : IGetCategoriesForSearchService
    {
        private readonly IDataBaseContext _context;

        public GetCategoriesForSearchService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ResultGetCategoriesForSearch> Execute()
        {
            var category = _context.Categories
                .Where(p => p.ParentCategoryId == null)
                .Select(p => new CategoryDto
                {
                    CatId = p.Id,
                    CategoryName = p.Name,
                }).ToList();

            return new ResultDto<ResultGetCategoriesForSearch>()
            {
                Data = new ResultGetCategoriesForSearch()
                {
                    CategoryDtos = category
                },
                IsSuccess = true,
            };
        }
    }
}