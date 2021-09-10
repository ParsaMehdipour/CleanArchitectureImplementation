using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace CA.Application.Services.Users.Queries.GetUsers
{
    public class GetUserDto
    {
        public long Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; }
    }
}
