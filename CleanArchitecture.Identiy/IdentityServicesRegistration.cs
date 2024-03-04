using CleanArchitecture.Application.Contracts.Identity;
using CleanArchitecture.Identiy.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
 using Microsoft.IdentityModel.Tokens;
using System.Runtime.CompilerServices;
using CleanArchitecture.Identiy.DbContext;
using Microsoft.AspNetCore.Identity;

namespace CleanArchitecture.Identiy
{
    public static class IdentityServicesRegistration
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddIdentityCore<IdentityUser>();
            //    .AddEntityFrameworkStores<CleanArchitectureIdentityDbConext>()
            //    .AddDefaultTokenProviders();
            return services;
        }
    }
}
