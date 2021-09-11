using System.Collections.Generic;
using CA.Domain.Entities.Common;

namespace CA.Domain.Entities.Category
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }

        public virtual Category ParentCategory { get; set; }
        public long? ParentCategoryId { get; set; }


        //برای نمایش زیر دسته های هر گروه
        public virtual ICollection<Category> SubCategories { get; set; }

    }
}
