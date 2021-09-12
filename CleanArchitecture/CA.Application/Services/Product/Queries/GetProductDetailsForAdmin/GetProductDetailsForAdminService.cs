using System.Linq;
using CA.Application.Interfaces.Contexts;
using CA.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Services.Product.Queries.GetProductDetailsForAdmin
{
    public class GetProductDetailsForAdminService : IGetProductDetailsForAdminService
    {
        private readonly IDataBaseContext _context;

        public GetProductDetailsForAdminService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ProductDetailsForAdminDto> Execute(long id)
        {
            var product = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImages)
                .FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                return new ResultDto<ProductDetailsForAdminDto>()
                {
                    Data = new ProductDetailsForAdminDto()
                    {
                        Brand = product.Brand,
                        Category = GetCategory(product.Category),
                        Description = product.Description,
                        Displayed = product.Displayed,
                        Id = product.Id,
                        Inventory = product.Inventory,
                        Name = product.Name,
                        Price = product.Price,
                        Features = product.ProductFeatures.Select(p => new ProductDetailsFeatureDto
                        {
                            Id = p.Id,
                            DisplayName = p.DisplayName,
                            Value = p.Value
                        }).ToList(),
                        Images = product.ProductImages.Select(p => new ProductDetailsImagesDto
                        {
                            Id = p.Id,
                            Src = p.Src,
                        }).ToList(),
                    },
                    IsSuccess = true,
                    Message = "",
                };
            }

            return new ResultDto<ProductDetailsForAdminDto>()
            {
                IsSuccess = false,
                Message = "محصولی با این آیدی وجود ندارد"
            };
        }

        private string GetCategory(Domain.Entities.Category.Category category)
        {
            string result = category.ParentCategory != null ? $"{category.ParentCategory.Name} - " : "";
            return result += category.Name;
        }
    }
}