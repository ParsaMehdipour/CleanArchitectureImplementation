using System.Collections.Generic;
using System.Linq;
using CA.Application.Interfaces.Contexts;
using CA.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Services.Common.Queries.GetMenuItem
{
    public class GetMenuItemService : IGetMenuItemService
    {
        private readonly IDataBaseContext _context;
        public GetMenuItemService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ResultMenuItemDto> Execute()
        {
            var category = _context.Categories
                .Where(p=> p.ParentCategoryId == null)
                .Select(p => new MenuItemDto
                {
                    CatId = p.Id,
                    Name = p.Name,
                    Child = p.SubCategories.Select(child => new MenuItemDto
                    {
                        CatId = child.Id,
                        Name = child.Name,
                    }).ToList(),
                }).ToList();

            return new ResultDto<ResultMenuItemDto>()
            {
                Data = new ResultMenuItemDto()
                {
                    MenuItemDtos = category
                },
                IsSuccess = true,
            };
        }
    }
}