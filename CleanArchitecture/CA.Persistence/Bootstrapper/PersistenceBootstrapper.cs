using CA.Application.Interfaces.Contexts;
using CA.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
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
        }
    }
}
