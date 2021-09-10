using CA.Common.Dto;

namespace CA.Application.Services.Users.Commands.LoginUser
{
    public interface ILoginUserService
    {
        ResultDto<ResultUserloginDto> Execute(string Username, string Password);
    }
}
