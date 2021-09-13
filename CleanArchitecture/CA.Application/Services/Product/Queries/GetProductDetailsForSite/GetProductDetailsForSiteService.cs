using System;
using System.Linq;
using CA.Application.Interfaces.Contexts;
using CA.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Services.Product.Queries.GetProductDetailsForSite
{
    public class GetProductDetailsForSiteService : IGetProductDetailsForSiteService
    {
        private readonly IDataBaseContext _context;
        public GetProductDetailsForSiteService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ProductDetailsForSiteDto> Execute(long Id)
        {
            var Product = _context.Products
                .Include(p=>p.Category)
                .ThenInclude(p=>p.ParentCategory)
                .Include(p=> p.ProductImages)
                .Include(p=> p.ProductFeatures).FirstOrDefault(p => p.Id==Id);

            if(Product == null)
            {
                throw new Exception("Product Not Found.....");
            }

            return new ResultDto<ProductDetailsForSiteDto>()
            {
                Data = new ProductDetailsForSiteDto
                {
                    Brand = Product.Brand,
                    Category = $"{Product.Category.ParentCategory.Name}  - {Product.Category.Name}",
                    Description = Product.Description,
                    Id = Product.Id,
                    Price = Product.Price,
                    Title = Product.Name,
                    Images = Product.ProductImages.Select(p => p.Src).ToList(),
                    Features = Product.ProductFeatures.Select(p => new ProductDetailsForSiteFeaturesDto
                    {
                        DisplayName = p.DisplayName,
                        Value = p.Value,
                    }).ToList(),

                },
                IsSuccess = true,
            };

        }
    }
}