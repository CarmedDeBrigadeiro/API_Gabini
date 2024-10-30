using Core.Interfaces;
using Infrastructure.Data;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Ports.Services;

var builder = WebApplication.CreateBuilder(args);

// Configura��o da inje��o de depend�ncias
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();


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
