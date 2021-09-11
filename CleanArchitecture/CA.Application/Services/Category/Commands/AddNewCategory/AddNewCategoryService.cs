using CA.Application.Interfaces.Contexts;
using CA.Common.Dto;

namespace CA.Application.Services.Category.Commands.AddNewCategory
{
    public class AddNewCategoryService : IAddNewCategoryService
    {
        private readonly IDataBaseContext _context;
        public AddNewCategoryService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long? ParentId, string Name)
        {
            if (string.IsNullOrEmpty(Name))
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "نام دسته بندی را وارد نمایید",
                };
            }

            Domain.Entities.Category.Category category = new Domain.Entities.Category.Category()
            {
                Name = Name,
                ParentCategory = GetParent(ParentId)
            };
            _context.Categories.Add(category);
            _context.SaveChanges();

            return new ResultDto()
            {
                IsSuccess = true,
                Message = "دسته بندی با موفقیت اضافه شد",
            };
            
        }

        private Domain.Entities.Category.Category GetParent(long? ParentId)
        {
            return _context.Categories.Find(ParentId);
        }
    }
}