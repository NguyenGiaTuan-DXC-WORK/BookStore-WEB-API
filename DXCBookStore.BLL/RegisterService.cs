using DXCBookStore.BLL.Business;
using DXCBookStore.BLL.Interfaces;
using DXCBookStore.DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;

namespace DXCBookStore.BLL
{
    public static class RegisterService
    {
        public static void AddBLLService(this IServiceCollection services, IConfiguration configuration)
        {
            // Add services from DAL
            services.AddDALService(configuration);

            // Inject service
            services.AddScoped<ISerieManagement, SerieManagement>();
            services.AddScoped<ICategoryManagement, CategoryManagement>();
            services.AddScoped<IBookManagement, BookManagement>();
            services.AddScoped<IPublisherManagement, PublisherManagement>();
            services.AddScoped<IAccountManagement, AccountManagement>();
            services.AddScoped<IAdminManagement, AdminManagement>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<ICustomerManagement, CustomerManagement>();
            services.AddScoped<IInvoiceManagement, InvoiceManagement>();
            services.AddScoped<IInvoiceDetailManagement, InvoiceDetailManagement>();
            services.AddScoped<IReportManagement, ReportManangement>();


        }
    }
}
