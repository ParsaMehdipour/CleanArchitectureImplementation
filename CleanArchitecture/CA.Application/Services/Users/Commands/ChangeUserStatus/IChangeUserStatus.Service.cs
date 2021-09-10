using CA.Common.Dto;

namespace CA.Application.Services.Users.Commands.ChangeUserStatus
{
    public interface IChangeUserStatusService
    {
        ResultDto Execute(long UserId);
    }
}
