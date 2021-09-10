using System.Collections.Generic;
using CA.Common.Dto;

namespace CA.Application.Services.Roles.Queries
{
    public interface IGetRolesService
    {
        ResultDto<List<RolesDto>> Execute();
    }
}
