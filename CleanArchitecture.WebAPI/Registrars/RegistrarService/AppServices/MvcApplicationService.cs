using Asp.Versioning.ApiExplorer;
using CleanArchitecture.WebAPI.Registrars.IRegistrarService;
using Microsoft.AspNetCore.SpaServices.AngularCli;

namespace CleanArchitecture.WebAPI.Registrars.RegistrarService.AppServices
{
    public class MvcApplicationService : IWebApplicationRegistrar
    {
        public void RegistrarApplicationServices(WebApplication app)
        {
            string CorsOrigins = "CorsOrigins";

            app.UseSwagger();
            app.UseSwaggerUI(options =>
            {
                foreach (var description in app.Services.GetRequiredService<IApiVersionDescriptionProvider>().ApiVersionDescriptions)
                {
                    options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToString());
                }
            });

            app.UseStaticFiles();
            app.UseRouting();

            // If in development, use Angular CLI server
            if (app.Environment.IsProduction())
            {
                app.UseSpa(spa =>
                {
                    spa.Options.SourcePath = Path.Combine(Directory.GetCurrentDirectory(), "ClientApp", "StrideMemoFrontEnd");
                    spa.UseAngularCliServer(npmScript: "start");
                });
            }

            app.UseCors(CorsOrigins);
            app.UseAuthorization();
        }
    }
}
