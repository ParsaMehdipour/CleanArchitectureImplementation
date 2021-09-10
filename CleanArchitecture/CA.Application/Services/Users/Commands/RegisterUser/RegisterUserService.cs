using System.Collections.Generic;
using CA.Application.Interfaces.Contexts;
using CA.Common.Dto;
using CA.Domain.Entities.Users;

namespace CA.Application.Services.Users.Commands.RegisterUser
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;

        public RegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto<ResultRegisterUserDto> Execute(RequestRegisterUserDto request)
        {
            var user = new User()
            {
                Name = request.FullName,
                Email = request.Email
            };

            var userInRoles = new List<UserRole>();

            foreach (var item in request.Roles)
            {
                var role = _context.Roles.Find(item.Id);

                userInRoles.Add(new UserRole
                {
                    RoleId = role.Id,
                    Role = role,
                    User = user,
                    UserId = user.Id
                });
            }

            user.UserRoles = userInRoles;

            _context.SaveChanges();

            return new ResultDto<ResultRegisterUserDto>()
            {
                Data = new ResultRegisterUserDto()
                {
                    UserId = user.Id
                },

                IsSuccess = true,
                Message = "کاربر با موفقیت ثبت نام شد"

            };
        }
    }
}