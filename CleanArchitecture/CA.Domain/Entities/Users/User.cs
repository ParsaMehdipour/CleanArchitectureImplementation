using System.Collections.Generic;

namespace CA.Domain.Entities.Users
{
    public class User
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
