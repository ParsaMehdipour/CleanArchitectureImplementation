﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text.RegularExpressions;
using CA.Application.Services.Users.Commands.LoginUser;
using CA.Application.Services.Users.Commands.RegisterUser;
using CA.Common.Dto;
using EndPoint.Site.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint.Site.Controllers
{
    public class AuthenticationController : Controller
    {

        private readonly IRegisterUserService _registerUserService;
        private readonly ILoginUserService _userLoginService;

        public AuthenticationController(IRegisterUserService registerUserService, ILoginUserService userLoginService)
        {
            _registerUserService = registerUserService;
            _userLoginService = userLoginService;
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignUp(SignUpViewModel request)
        {
            if (string.IsNullOrWhiteSpace(request.FullName) ||
                string.IsNullOrWhiteSpace(request.Email) ||
                string.IsNullOrWhiteSpace(request.Password) ||
                string.IsNullOrWhiteSpace(request.RePassword))
            {
                return Json(new ResultDto { IsSuccess = false, Message = "لطفا تمامی موارد رو ارسال نمایید" });
            }

            if (User.Identity.IsAuthenticated == true)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "شما به حساب کاربری خود وارد شده اید! و در حال حاضر نمیتوانید ثبت نام مجدد نمایید" });
            }
            if (request.Password != request.RePassword)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "رمز عبور و تکرار آن برابر نیست" });
            }
            if (request.Password.Length < 8)
            {
                return Json(new ResultDto { IsSuccess = false, Message = "رمز عبور باید حداقل 8 کاراکتر باشد" });
            }

            string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";

            var match = Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase);
            if (!match.Success)
            {
                return Json(new ResultDto { IsSuccess = true, Message = "ایمیل خودرا به درستی وارد نمایید" });
            }
           

            var signeUpResult = _registerUserService.Execute(new RequestRegisterUserDto
            {
                Email = request.Email,
                FullName = request.FullName,
                Password = request.Password,
                RePassword = request.RePassword,
                Roles = new List<RoleInRegisterUserDto>()
                {
                     new RoleInRegisterUserDto() { Id = 3},
                }
            });

            if (signeUpResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,signeUpResult.Data.UserId.ToString()),
                new Claim(ClaimTypes.Email, request.Email),
                new Claim(ClaimTypes.Name, request.FullName),
                new Claim(ClaimTypes.Role, "Customer"),
            };
           

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true
                };
               HttpContext.SignInAsync(principal, properties);
 
            }
            return Json(signeUpResult);
        }


        public IActionResult SignIn(string ReturnUrl = "/")
        {
            ViewBag.url = ReturnUrl;
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(string Email, string Password, string url = "/")
        {
            var signInResult = _userLoginService.Execute(Email, Password);
            if (signInResult.IsSuccess == true)
            {
                var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier,signInResult.Data.UserId.ToString()),
                new Claim(ClaimTypes.Email, Email),
                new Claim(ClaimTypes.Name, signInResult.Data.Name),
                new Claim(ClaimTypes.Role, signInResult.Data.Roles ),
            };
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);
                var properties = new AuthenticationProperties()
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTime.Now.AddDays(5),
                };
               HttpContext.SignInAsync(principal, properties);
            
            }
            return Json(signInResult);
        }


        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
         
            return RedirectToAction("Index", "Home");
        }
    }
}
