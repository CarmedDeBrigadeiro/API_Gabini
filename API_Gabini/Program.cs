using Core.Interfaces;
using Core.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using API_Gabini.Data;
using Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configuração da injeção de dependências
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Registro de repositórios e serviços
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<IUserService, UserService>();

// Adicione a configuração do Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "API_Gabini", Version = "v1" });
});

// Chamada do método para adicionar controladores
builder.Services.AddControllers();

var app = builder.Build();

// Configuração do middleware Swagger
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

// Habilita o middleware do Swagger
app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "API_Gabini v1")); 

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
