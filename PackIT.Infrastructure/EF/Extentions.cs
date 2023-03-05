using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PackIT.Application.Repositories;
using PackIT.Application.Services;
using PackIT.Infrastructure.EF.Contexts;
using PackIT.Infrastructure.EF.Repositories;
using PackIT.Infrastructure.EF.Services;

namespace PackIT.Infrastructure.EF
{
    internal static class Extensions
    {
        public static IServiceCollection AddSQLServer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPackingListRepository, SqlServerPackingListRepository>();
            services.AddScoped<IPackingListReadService, SqlServerPackingListReadService>();

            services.AddDbContext<ReadDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DbConnection"]);
            });
            services.AddDbContext<WriteDbContext>(options =>
            {
                options.UseSqlServer(configuration["ConnectionStrings:DbConnection"]);
            });

            return services;
        }
    }
}
