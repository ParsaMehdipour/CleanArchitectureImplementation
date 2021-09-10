using CA.Application.Interfaces.Contexts;
using CA.Application.Services.Roles.Queries;
using CA.Application.Services.Users.Commands.RegisterUser;
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
        }
    }
}
