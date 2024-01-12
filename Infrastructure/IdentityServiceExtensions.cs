using Infrastructure.Identity;
using Infrastructure.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public static class IdentityServiceExtensions
    {
        public static void AddIdentityServices(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddAuthentication(IdentityConstants.ApplicationScheme).AddIdentityCookies();

            //service.AddIdentityCore<ApplicationUser>().AddEntityFrameworkStores<TenantUsuarioDbContext>();
                /*
              .AddDefaultIdentity<ApplicationUser>()
              .AddRoles<IdentityRole>()
              .AddEntityFrameworkStores<TenantProductoDbContext>()
              .AddDefaultTokenProviders();*/


        }
    }
}
