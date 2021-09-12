using System;
using System.Linq;
using System.Text.RegularExpressions;
using CA.Application.Interfaces.Contexts;
using CA.Common;
using CA.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Services.Product.Queries.GetProductsForAdmin
{
    public class GetProductsForAdminService : IGetProductsForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetProductsForAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ResultProductsForAdminDto> Execute(int Page = 1, int PageSize = 20)
        {
            int rowCount = 0;
            var products = _context.Products
                .ToPaged(Page, PageSize, out rowCount)
                .Select(p => new ProductForAdminListDto()
                {
                    Id = p.Id,
                    Brand = p.Brand,
                    Category = p.Category.Name,
                    Description = p.Description.Substring(0, Math.Min(p.Description.Length, 50)) + "...",
                    Displayed = p.Displayed,
                    Inventory = p.Inventory,
                    Name = p.Name,
                    Price = p.Price,
                }).ToList();

            return new ResultDto<ResultProductsForAdminDto>()
            {
                Data = new ResultProductsForAdminDto()
                {
                    Products = products,
                    CurrentPage = Page,
                    PageSize = PageSize,
                    RowCount = rowCount
                },
                IsSuccess = true,
                Message = "",
            };
        }
    }
}