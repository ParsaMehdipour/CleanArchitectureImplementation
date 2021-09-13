using System.Collections.Generic;
using CA.Common.Dto;

namespace CA.Application.Services.Common.Queries.GetMenuItem
{
    public interface IGetMenuItemService
    {
        ResultDto<ResultMenuItemDto> Execute();   
    }
}
