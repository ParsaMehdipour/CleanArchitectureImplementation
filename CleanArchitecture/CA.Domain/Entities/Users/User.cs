using System.Collections.Generic;
using CA.Domain.Entities.Common;

namespace CA.Domain.Entities.Users
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}
