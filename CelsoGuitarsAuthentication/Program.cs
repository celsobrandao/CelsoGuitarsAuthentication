using CelsoGuitars.Application;
using CelsoGuitarsAuthentication.API.Configuration;
using CelsoGuitarsAuthentication.Domain.Usuario.Repository;
using CelsoGuitarsAuthentication.Infra.Repository;
using CelsoGuitarsAuthentication.Repository;
using CelsoGuitarsAuthentication.Repository.Context;
using CelsoGuitarsAuthentication.Repository.Database;
using CelsoGuitarsAuthentication.Repository.Repository.Usuario;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.ConfigureAuthentication(builder);

builder.Services.AddControllers();

builder.Services
    .RegisterApplication()
    .RegisterRepository(builder.Configuration.GetConnectionString("CelsoGuitarsAuthentication"));

builder.Services.AddDbContext<CelsoGuitarsAuthenticationContext>(c =>
{
    c.UseSqlServer(builder.Configuration.GetConnectionString("CelsoGuitarsAuthentication"));
});

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

#region Usuario
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
#endregion

builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
