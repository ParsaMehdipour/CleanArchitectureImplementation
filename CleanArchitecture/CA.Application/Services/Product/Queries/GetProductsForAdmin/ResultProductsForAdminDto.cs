using System.Collections.Generic;

namespace CA.Application.Services.Product.Queries.GetProductsForAdmin
{
    public class ResultProductsForAdminDto
    {
        ///<summary>
        /// For Pagination
        /// </summary>
        public int RowCount { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public List<ProductForAdminListDto> Products { get; set; }
    }
}