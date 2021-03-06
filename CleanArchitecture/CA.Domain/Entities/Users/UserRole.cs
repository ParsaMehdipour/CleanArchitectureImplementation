namespace CA.Domain.Entities.Users
{
    public class UserRole
    {
        public long Id { get; set; }

        public long UserId { get; set; }
        public User User { get; set; }

        public long RoleId { get; set; }
        public Role Role { get; set; }
        public bool IsRemoved { get; set; }
    }
}