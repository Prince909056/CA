using CleanArchitecture.WebAPI.Options;
using CleanArchitecture.WebAPI.Registrars.IRegistrarService;

namespace CleanArchitecture.WebAPI.Registrars.RegistrarService.BuilderServices
{
    public class SwaggerBuilderService : IWebApplicationBuilderRegistrar
    {
        public void RegistrarBuilderServices(WebApplicationBuilder builder)
        {
            builder.Services.ConfigureOptions<ConfigureSwaggerOption>();
            builder.Services.AddSwaggerGen();
        }
    }
}
