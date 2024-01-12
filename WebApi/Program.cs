
using Application;
using Application.Contracts.Persistence;
using Infrastructure.Identity;
using Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using WebApi;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

// Adding MediatR
builder.Services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());


//var connectionString = builder.Configuration.GetConnectionString("AppDb");
builder.Services.AddDbContext<TenantUsuarioDbContext>();
builder.Services.AddDbContext<TenantProductoDbContext>();


builder.Services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
builder.Services.AddScoped(typeof(IUsuarioRepository), typeof(UsuarioRepository));
builder.Services.AddScoped(typeof(IProductoRepository), typeof(ProductoRepository));



builder.Services.AddScoped(typeof(IOrganizacionUsuarioRepository), typeof(OrganizacionUsuarioRepository));
builder.Services.AddScoped(typeof(IOrganizacionProductoRepository), typeof(OrganizacionProductoRepository));


//builder.Services.AddScoped(typeof(ITokenGenerator), typeof(TokenGenerator));


//builder.Services.AddScoped(typeof(IIdentityService), typeof(IdentityService));

builder.Services.AddScoped(typeof(ITenantContext), typeof(TenantContext));

builder.Services.AddApplicationServices();


/*builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddDefaultTokenProviders();
builder.Services.AddScoped<IIdentityService, IdentityService>();*/



//builder.Services..AddInfrastructureServices(builder.Configuration);
//builder.Services.AddWebUIServices(builder.Configuration);
// Add services to the container.

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(o =>
{
    o.TokenValidationParameters = new TokenValidationParameters
    {
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey
        (Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"])),
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = false,
        ValidateIssuerSigningKey = true
    };
});


builder.Services.AddAuthorization();




builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "WebApi v1"));
}

// app.UseHttpsRedirection();
app.UseCors("TestCors");
//app.UseAuthorization();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();


/*using Microsoft.AspNetCore.Builder;

var builder = WebApplication.CreateBuilder(args);

var app = builder.Build();

app.MapGet("/");
app.Run();
*/
/*using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    
                    webBuilder.UseStartup<Startup>();
                });
    }
}*/
