namespace CA.Application.Services.Users.Queries.GetUsers
{
    public interface IGetUsersService
    {
        ResultGetUsersDto Execute(RequestGetUsersDto request);
    }
}
