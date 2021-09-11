using CA.Common.Dto;

namespace CA.Application.Services.Category.Commands.AddNewCategory
{
    public interface IAddNewCategoryService
    {
        ResultDto Execute(long? ParentId, string Name);
    }
}
