using CA.Application.Interfaces.Contexts;
using CA.Application.Interfaces.FacadePatterns;
using CA.Application.Services.Category.Commands.AddNewCategory;
using CA.Application.Services.Category.Queries.GetCategories;

namespace CA.Application.Services.Category.FacadePattern
{
    public class CategoryFacadePattern : ICategoryFacadePattern
    {
        private readonly IDataBaseContext _context;

        public CategoryFacadePattern(IDataBaseContext context)
        {
            _context = context;
        }

        private AddNewCategoryService _addNewCategoryService;

        public AddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategoryService ??= new AddNewCategoryService(_context);
            }
        }

        private IGetCategoriesService _getCategoriesService;

        public IGetCategoriesService GetCategoriesService
        {
            get
            {
                return _getCategoriesService ??= new GetCategoriesService(_context);
            }
        }
    }
}
