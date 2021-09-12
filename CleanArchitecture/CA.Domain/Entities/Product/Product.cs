using System.Collections.Generic;
using CA.Domain.Entities.Common;

namespace CA.Domain.Entities.Product
{
    public class Product : BaseEntity
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; } //To Be Displayed In Site

        public virtual Category.Category Category { get; set; }//Each Product Has One Product Category
        public long CategoryId { get; set; }

        public virtual ICollection<ProductImages> ProductImages { get; set; }//Each Product Has Many Images
        public virtual ICollection<ProductFeatures> ProductFeatures { get; set; }//Each Product Has Many Features
    }
}
