using CA.Common.Dto;

namespace CA.Application.Services.Users.Commands.RemoveUser
{
    public interface IRemoveUserService
    {
        ResultDto Execute(long userId);
    }
}
