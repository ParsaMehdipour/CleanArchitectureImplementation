using System.Collections.Generic;
using System.Linq;
using CA.Application.Interfaces.Contexts;
using CA.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Services.Category.Queries.GetCategories
{
    public class GetCategoriesService : IGetCategoriesService
    {
        private readonly IDataBaseContext _context;

        public GetCategoriesService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<List<CategoriesDto>> Execute(long? ParentId)
        {
            var categories = _context.Categories
                .Where(p => p.ParentCategoryId == ParentId)
                .Select(p => new CategoriesDto
                {
                    Id = p.Id,
                    Name = p.Name,
                    Parent = p.ParentCategory != null ? new
                            ParentCategoryDto
                            {
                                Id = p.ParentCategory.Id,
                                name = p.ParentCategory.Name,
                            }
                        : null,
                    HasChild = p.SubCategories.Count() > 0 ? true : false,
                }).ToList();


            return new ResultDto<List<CategoriesDto>>()
            {
                Data = categories,
                IsSuccess = true,
                Message = "لیست باموقیت برگشت داده شد"
            };

        }
    }
}