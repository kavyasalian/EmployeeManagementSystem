
using EmployeeManagement.Data;
using System.Security.Claims;

namespace  EmployeeManagement.Web.Infrastructure
{
    public static class ApplicationMiddlewareExtensions
    {
        public static IApplicationBuilder UseApplicationMiddleware(this IApplicationBuilder applicationBuilder)
        {
            return applicationBuilder.UseMiddleware<ApplicationMiddleware>();
        }
    }

    public class ApplicationMiddleware
    {
        private readonly RequestDelegate next;

        public ApplicationMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context, ApplicationContext applicationContext)
        {
            if (context.User.Identity.IsAuthenticated)
            {
                if (int.TryParse(context.User.Claims.Single(x => x.Type == ClaimTypes.NameIdentifier).Value, out int userId))
                {
                    applicationContext.UserId = userId;
                }

                //if (context.User.Claims.Any(x => x.Type == Constants.DivisionId))
                //{
                //    applicationContext.DivisionId = Convert.ToInt32(context.User.Claims.First(x => x.Type == Constants.DivisionId).Value);
                //}

                //TODO: Populate tenantId from request header
                //if (context.User.Claims.Any(x => x.Type == Constants.TenantId))
                //{
                //    applicationContext.TenantId = Convert.ToInt32(context.User.Claims.First(x => x.Type == Constants.TenantId).Value);
                //}

                applicationContext.UserEmail = context.User.Claims.SingleOrDefault(x => x.Type == ClaimTypes.Email)?.Value;
            }

            await this.next.Invoke(context);
        }
    }
}
