using Application.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Services;

namespace WebApi
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddWebUIServices(this IServiceCollection services, IConfiguration configuration)
        {
            //services.AddDatabaseDeveloperPageExceptionFilter();

            services.AddSingleton<ICurrentUserService, CurrentUserService>();

            services.AddHttpContextAccessor();

            services.AddCors(options =>
            {
                options.AddPolicy(name: "TestCors", policy =>
                {
                    var allowedHost = configuration.GetValue<string>("CustomConfig:AllowedHost");
                    policy.SetIsOriginAllowed(origin => new Uri(origin).Host == allowedHost)
                        .AllowAnyHeader();

                });
            });

            // services.AddHealthChecks()
            //     .AddDbContextCheck<ApplicationDbContext>();

            // services.AddControllersWithViews(options =>
            //     options.Filters.Add<ApiExceptionFilterAttribute>())
            //         .AddFluentValidation(x => x.AutomaticValidationEnabled = false);

            // services.AddRazorPages();

            // Customise default API behaviour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // services.AddOpenApiDocument(configure =>
            // {
            //     configure.Title = "ApiSAP API";
            //     configure.AddSecurity("JWT", Enumerable.Empty<string>(), new OpenApiSecurityScheme
            //     {
            //         Type = OpenApiSecuritySchemeType.ApiKey,
            //         Name = "Authorization",
            //         In = OpenApiSecurityApiKeyLocation.Header,
            //         Description = "Type into the textbox: Bearer {your JWT token}."
            //     });
            //
            //     configure.OperationProcessors.Add(new AspNetCoreOperationSecurityScopeProcessor("JWT"));
            // });

            return services;
        }

    }
}
