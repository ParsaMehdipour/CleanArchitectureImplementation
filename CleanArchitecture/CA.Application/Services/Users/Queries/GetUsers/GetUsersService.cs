using System.Linq;
using CA.Application.Interfaces.Contexts;
using CA.Common;
using Microsoft.EntityFrameworkCore;

namespace CA.Application.Services.Users.Queries.GetUsers
{
    public class GetUsersService : IGetUsersService
    {
        private readonly IDataBaseContext _context;

        public GetUsersService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultGetUsersDto Execute(RequestGetUsersDto request)
        {
            var users = _context.Users.AsQueryable();

            if (string.IsNullOrWhiteSpace(request.SearchKey) is false)
            {
                users = users.Where(x => x.Name.Contains(request.SearchKey) || x.Email.Contains(request.SearchKey));
            }

            int rowsCount = 0;
            var usersList = users.AsEnumerable().ToPaged(request.Page, 20, out rowsCount).Select(p => new GetUserDto
            {
                Email = p.Email,
                FullName = p.Name,
                Id = p.Id,
            }).ToList();


            var result = new ResultGetUsersDto()
            {
                GetUserDtos = usersList,
                Rows = rowsCount
            };

            return result;
        }
    }
}
