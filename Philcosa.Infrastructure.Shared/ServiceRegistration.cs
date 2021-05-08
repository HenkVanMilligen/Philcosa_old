using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Philcosa.Application.Interfaces;
using Philcosa.Domain.Settings;
using Philcosa.Infrastructure.Shared.Services;

namespace Philcosa.Infrastructure.Shared
{
    public static class ServiceRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration _config)
        {
            services.Configure<MailSettings>(_config.GetSection("MailSettings"));
            services.AddTransient<IDateTimeService, DateTimeService>();
            services.AddTransient<IEmailService, EmailService>();
        }
    }
}
