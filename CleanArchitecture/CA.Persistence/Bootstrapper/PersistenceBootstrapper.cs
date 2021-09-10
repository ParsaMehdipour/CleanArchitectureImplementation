using CA.Application.Interfaces.Contexts;
using CA.Application.Services.Roles.Queries;
using CA.Application.Services.Users.Commands.ChangeUserStatus;
using CA.Application.Services.Users.Commands.EditUser;
using CA.Application.Services.Users.Commands.LoginUser;
using CA.Application.Services.Users.Commands.RegisterUser;
using CA.Application.Services.Users.Commands.RemoveUser;
using CA.Application.Services.Users.Queries.GetUsers;
using CA.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace CA.Persistence.Bootstrapper
{
    public class PersistenceBootstrapper
    {
        public static void Configure(IServiceCollection services, string connectionstring)
        {
            services.AddDbContext<DataBaseContext>(options =>
            {
                options.UseSqlServer(connectionstring);
            });


            services.AddTransient<IDataBaseContext, DataBaseContext>();
            services.AddTransient<IGetUsersService, GetUsersService>();
            services.AddTransient<IRegisterUserService, RegisterUserService>();
            services.AddTransient<IGetRolesService, GetRolesService>();
            services.AddTransient<IRemoveUserService, RemoveUserService>();
            services.AddTransient<IChangeUserStatusService, ChangeUserStatusService>();
            services.AddTransient<IEditUserService, EditUserService>();
            services.AddTransient<ILoginUserService, LoginUserService>();
        }
    }
}
