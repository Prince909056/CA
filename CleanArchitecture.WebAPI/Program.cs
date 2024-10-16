using CleanArchitecture.WebAPI.RegistrarExtensions;

var builder = WebApplication.CreateBuilder(args);
builder.RegistrarBuilderExtension(typeof(Program));

var app = builder.Build();
app.RegistrarApplicationExtension(typeof(Program));
app.Run();