namespace CA.Application.Services.Users.Queries.GetUsers
{
    public class RequestGetUsersDto
    {
        public string SearchKey { get; set; }
        public int Page { get; set; } = 1;
    }
}
