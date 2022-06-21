using EmployeeManagement.Data;
using EmployeeManagement_Business;

namespace EmployeeManagement.Web.Infrastructure
{
    public static class DependencyRegistry
    {
        public static void RegisterDependency(this IServiceCollection services,AppSettings appSettings)
        {
            services.AddSingleton<IHttpContextAccessor , HttpContextAccessor>();
            services.AddSingleton(appSettings);
            services.AddScoped<ApplicationContext>();
            services.AddMemoryCache();
            BusinessDependencyRegistry.RegisterDependency(services,appSettings); 
        }
    }
}
