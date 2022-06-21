using EmployeeManagement.Data;
using EmployeeManagement_Repository;
using Microsoft.Extensions.DependencyInjection;


namespace EmployeeManagement_Business
{
    public static class BusinessDependencyRegistry
    {
        public static void RegisterDependency(this IServiceCollection services, AppSettings appSettings)
        {
           // SQLDependencyRegistry.DependencyRegistry(services, appSettings);
            services.AddTransient<UserBusiness>();
        }
    }
}
