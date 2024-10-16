using Asp.Versioning;
using CleanArchitecture.Persistence.Context;
using CleanArchitecture.WebAPI.Registrars.IRegistrarService;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.WebAPI.Registrars.RegistrarService.BuilderServices
{
    public class MvcBuilderService : IWebApplicationBuilderRegistrar
    {
        public void RegistrarBuilderServices(WebApplicationBuilder builder)
        {
            string CorsOrigins = "CorsOrigins";
            var connectionString = builder.Configuration.GetConnectionString("default");

            builder.Services.AddControllers();
            builder.Services.AddFluentValidationAutoValidation();
            builder.Services.AddApiVersioning(options =>
            {
                options.DefaultApiVersion = new ApiVersion(1, 0);
                options.ReportApiVersions = true;
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new UrlSegmentApiVersionReader();
            }).AddApiExplorer(options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            builder.Services.AddEndpointsApiExplorer();

            builder.Services.AddAutoMapper(typeof(Program)); // Register Auto Mapper

            builder.Services.AddDbContext<StrideMemoDbContext>(x =>
            {
                x.UseSqlServer(connectionString);
            });


            // CORS setup
            string? corsRaw = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (!string.IsNullOrEmpty(corsRaw))
            {
                string[] corsOrigins = corsRaw.Split(',');
                builder.Services.AddCors(options =>
                {
                    options.AddPolicy(name: CorsOrigins,
                        builder =>
                        {
                            builder.WithOrigins(corsOrigins)
                                .AllowAnyHeader()
                                .AllowCredentials()
                                .AllowAnyMethod();
                        });
                });
            }
        }
    }
}
