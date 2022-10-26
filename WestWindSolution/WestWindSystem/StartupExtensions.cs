using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WestwindSystem.BLL;
using WestWindSystem.BLL;
using WestWindSystem.DAL;

namespace WestwindSystem
{
    public static class StartupExtensions
    {
        public static void AddBackendDependencies(
            this IServiceCollection services,
            Action<DbContextOptionsBuilder> options)
        {
            services.AddDbContext<WestWindContext>(options);

            services.AddTransient<BuildVersionServices>(serviceProvider => {
                var context = serviceProvider.GetRequiredService<WestWindContext>();
                return new BuildVersionServices(context);
            });

            services.AddTransient<CategoryServices>(serviceProvider => {
                var context = serviceProvider.GetRequiredService<WestWindContext>();
                return new CategoryServices(context);
            });

        }
    }
}