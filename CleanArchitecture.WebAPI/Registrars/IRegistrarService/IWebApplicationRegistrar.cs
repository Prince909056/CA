namespace CleanArchitecture.WebAPI.Registrars.IRegistrarService
{
    public interface IWebApplicationRegistrar : IRegistrar
    {
        void RegistrarApplicationServices(WebApplication app);
    }
}
