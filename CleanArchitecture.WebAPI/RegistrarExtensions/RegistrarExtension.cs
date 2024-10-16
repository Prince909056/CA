using CleanArchitecture.WebAPI.Registrars.IRegistrarService;

namespace CleanArchitecture.WebAPI.RegistrarExtensions
{
    public static class RegistrarExtension
    {
        public static void RegistrarBuilderExtension(this WebApplicationBuilder builder, Type scanningType)
        {
            var registrars = GetRegistrars<IWebApplicationBuilderRegistrar>(scanningType);
            foreach (var registrar in registrars)
            {
                registrar.RegistrarBuilderServices(builder);
            }
        }
        public static void RegistrarApplicationExtension(this WebApplication app, Type scanningType)
        {
            var registrars = GetRegistrars<IWebApplicationRegistrar>(scanningType);
            foreach (var registrar in registrars)
            {
                registrar.RegistrarApplicationServices(app);
            }
        }
        public static IEnumerable<T> GetRegistrars<T>(Type scanningType)
            where T : IRegistrar
        {
            return scanningType.Assembly
                .GetTypes()
                .Where(t => t.IsAssignableTo(typeof(T)) && !t.IsAbstract && !t.IsInterface)
                .Select(Activator.CreateInstance)
                .Cast<T>();
        }
    }
}
