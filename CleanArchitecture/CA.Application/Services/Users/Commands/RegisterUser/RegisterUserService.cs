using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using CA.Application.Interfaces.Contexts;
using CA.Common;
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
            try
            {
                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "پست الکترونیک را وارد نمایید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "نام را وارد نمایید"
                    };
                }
                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور را وارد نمایید"
                    };
                }
                if (request.Password != request.RePassword)
                {
                    return new ResultDto<ResultRegisterUserDto>()
                    {
                        Data = new ResultRegisterUserDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور و تکرار آن برابر نیست"
                    };
                }

                var passwordHasher = new PasswordHasher();
                var hashedPassword = passwordHasher.HashPassword(request.Password);

                User user = new User()
                {
                    Email = request.Email,
                    Name = request.FullName,
                    Password = hashedPassword,
                    IsActive = true
                };

                List<UserRole> userInRoles = new List<UserRole>();

                foreach (var item in request.Roles)
                {
                    var roles = _context.Roles.Find(item.Id);
                    userInRoles.Add(new UserRole
                    {
                        Role = roles,
                        RoleId = roles.Id,
                        User = user,
                        UserId = user.Id,
                    });
                }
                user.UserRoles = userInRoles;

                _context.Users.Add(user);

                _context.SaveChanges();

                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = user.Id,

                    },
                    IsSuccess = true,
                    Message = "ثبت نام کاربر انجام شد",
                };
            }
            catch (Exception)
            {
                return new ResultDto<ResultRegisterUserDto>()
                {
                    Data = new ResultRegisterUserDto()
                    {
                        UserId = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام انجام نشد !"
                };
            }
        }
    }
}