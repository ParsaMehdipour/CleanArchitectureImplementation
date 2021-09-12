using System.Collections.Generic;
using System.Linq;
using CA.Application.Interfaces.Contexts;
using CA.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Services.Category.Queries.GetAllCategories
{
    public class GetAllCategoriesService : IGetAllCategoriesService
    {
        private readonly IDataBaseContext _context;

        public GetAllCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<AllCategoriesDto>> Execute()
        {
            var categories = _context
                .Categories
                .Include(p => p.ParentCategory)
                .Where(p => p.ParentCategoryId != null)
                .ToList()
                .Select(p => new AllCategoriesDto
                    {
                        Id = p.Id,
                        Name = $"{p.ParentCategory.Name} - {p.Name}",
                    }
                ).ToList();

            return new ResultDto<List<AllCategoriesDto>>
            {
                Data = categories,
                IsSuccess = false,
                Message = "",
            };
        }
    }
}