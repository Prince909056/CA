namespace CleanArchitecture.WebAPI.Registrars.IRegistrarService
{
    public interface IWebApplicationBuilderRegistrar : IRegistrar
    {
        void RegistrarBuilderServices(WebApplicationBuilder builder);
    }
}
