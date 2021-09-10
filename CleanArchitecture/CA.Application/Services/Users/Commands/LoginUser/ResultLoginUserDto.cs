namespace CA.Application.Services.Users.Commands.LoginUser
{
    public class ResultLoginUserDto
    {
        public long UserId { get; set; }
        public string Roles { get; set; }
        public string Name { get; set; }
    }
}