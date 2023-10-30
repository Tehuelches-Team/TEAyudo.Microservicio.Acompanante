using Application.Interfaces.Application;
using Application.Interfaces.Infraestructure.Command;
using Application.Interfaces.Infraestructure.Query;
using Application.UseCase.CrearUsuarioAcompante;
using Application.UseCase.Services;
using Infraestructure.Command;
using Infraestructure.Querys;
using Microsoft.EntityFrameworkCore;
using TEAyudo_Acompanantes;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<TEAyudoContext>(options =>
{
    options.UseSqlServer("Server=localhost;Database=TEAyudo_Acompanantes;Trusted_Connection=True;TrustServerCertificate=True;Persist Security Info=true");

});

builder.Services.AddTransient<IAcompanteService, AcompananteService>();
builder.Services.AddTransient<IDisponibilidadService, DisponibilidadService>();
builder.Services.AddTransient<IEspecialidadService, EspecialidadService>();
builder.Services.AddTransient<IObraSocialService, ObraSocialService>();
builder.Services.AddTransient<IAcompananteCommand, AcompananteCommand>();
builder.Services.AddTransient<IDisponibilidadCommand, DisponibilidadCommand>();
builder.Services.AddTransient<IEspecialidadCommand, EspecialidadCommand>();
builder.Services.AddTransient<IObraSocialCommand, ObraSocialCommand>();
builder.Services.AddTransient<IAcompananteQuery, AcompananteQuery>();
builder.Services.AddTransient<IEspecialidadQuery, EspecialidadQuery>();
builder.Services.AddTransient<IObraSocialQuery, ObraSocialQuery>();
builder.Services.AddTransient<IDisponibilidadQuery, DisponibilidadQuery>();
builder.Services.AddTransient<ICreateAcompananteResponse, CreateAcompananteResponse>();
builder.Services.AddTransient<IUsuarioCommand, UsuarioCommand>();
builder.Services.AddTransient<IUsuarioQuery, UsuarioQuery>();
builder.Services.AddTransient<IPropuestaCommand, PropuestaCommand>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
