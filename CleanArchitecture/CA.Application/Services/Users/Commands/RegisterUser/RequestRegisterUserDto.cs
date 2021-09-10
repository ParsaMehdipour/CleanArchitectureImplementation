using System.Collections.Generic;

namespace CA.Application.Services.Users.Commands.RegisterUser
{
    public class RequestRegisterUserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public List<RoleInRegisterUserDto> Roles { get; set; }
    }
}