using CA.Application.Interfaces.Contexts;
using CA.Common.Dto;

namespace CA.Application.Services.Users.Commands.ChangeUserStatus
{
    public class ChangeUserStatusService : IChangeUserStatusService
    {
        private readonly IDataBaseContext _context;


        public ChangeUserStatusService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long UserId)
        {
            var user = _context.Users.Find( UserId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }

            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            string userstate = user.IsActive == true ? "فعال" : "غیر فعال";
            return new ResultDto()
            {
                IsSuccess = true,
                Message = $"کاربر با موفقیت {userstate} شد!",
            };
        }
    }
}