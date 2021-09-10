using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace CA.Application.Services.Users.Queries.GetUsers
{
    public class ResultGetUsersDto
    {
        public List<GetUserDto> GetUserDtos { get; set; }
        public int Rows { get; set; }
    }
}
