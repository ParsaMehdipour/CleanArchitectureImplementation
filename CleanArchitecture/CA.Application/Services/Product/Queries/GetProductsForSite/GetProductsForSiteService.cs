using System;
using System.Linq;
using CA.Application.Interfaces.Contexts;
using CA.Common;
using CA.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Services.Product.Queries.GetProductsForSite
{
    public class GetProductsForSiteService : IGetProductsForSiteService
    {

        private readonly IDataBaseContext _context;
        public GetProductsForSiteService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultProductsForSiteDto> Execute(int Page)
        {
            var products = _context.Products
                .Include(p=>p.ProductImages)
                .ToPaged(Page, 5, out var totalRow);

            Random rd = new Random();
            return new ResultDto<ResultProductsForSiteDto>
            {
                Data = new ResultProductsForSiteDto
                {
                    TotalRow = totalRow,
                    Products = products.Select(p => new ProductForSiteDto
                    {
                        Id = p.Id,
                        Star = rd.Next(1, 5),
                        Title = p.Name,
                        ImageSrc = p.ProductImages.FirstOrDefault().Src,
                        Price=p.Price
                    }).ToList(),
                },
                IsSuccess = true,
            };
        }
    }
}