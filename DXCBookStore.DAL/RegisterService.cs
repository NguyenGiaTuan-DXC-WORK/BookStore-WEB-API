using DXCBookStore.DAL.DatabaseContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DXCBookStore.DAL
{
    public static class RegisterService
    {
        public static void AddDALService(this IServiceCollection services, IConfiguration configuration)
        {
            // Add db context service
            services.AddDbContext<DataContext>(options =>
                                               options.UseSqlServer(configuration.GetConnectionString("DbBookStoreConnection")));
        }
    }
}
