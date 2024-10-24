using Microsoft.AspNetCore.Diagnostics;

namespace Mds.TddExample.Api.Common.Exceptions
{
    public static class ConfigurationExtensions
    {
        public static void RegisterApiExceptions(this IServiceCollection services)
        {
            services.AddExceptionHandler<NotFoundExceptionHandler>();
        }
    }
}
