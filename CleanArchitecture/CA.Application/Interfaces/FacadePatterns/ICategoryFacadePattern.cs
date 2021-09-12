using CA.Application.Services.Category.Commands.AddNewCategory;
using CA.Application.Services.Category.Queries.GetAllCategories;
using CA.Application.Services.Category.Queries.GetCategories;

namespace CA.Application.Interfaces.FacadePatterns
{
    public interface ICategoryFacadePattern
    {
        public AddNewCategoryService AddNewCategoryService { get; }
        public IGetCategoriesService GetCategoriesService { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
    }
}
