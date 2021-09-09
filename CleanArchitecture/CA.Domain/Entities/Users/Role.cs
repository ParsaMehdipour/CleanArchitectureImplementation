using System.Collections.Generic;

namespace CA.Domain.Entities.Users
{
    public class Role
    {
        public long Id { get; set; }
        public string Name { get; set; }

        public List<UserRole> UserRoles { get; set; }
    }
}