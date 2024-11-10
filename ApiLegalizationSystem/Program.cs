using ApiLegalizationSystem.Data.Models;
using ApiLegalizationSystem.Domain.Mappers;
using ApiLegalizationSystem.Domain.UseCases;
using ApiLegalizationSystem.Domain.Utils;
using ApiLegalizationSystem.Presenter.Mappers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using ApiLegalizationSystem.Domain.Exceptions;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Inject the LegalizationSystemContext
builder.Services.AddDbContext<LegalizationContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuerySQLSetting"));
});

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ErrorHandler>(); // Agregar el filtro de excepciones personalizado
});

// Inject the UserDomainMapper, CreateUserUseCase and Helpper
try {
    builder.Services.AddScoped<UserDomainMapper>();
    builder.Services.AddScoped<UserPresenterMapper>();
    builder.Services.AddScoped<CreateUserUseCase>();
    builder.Services.AddScoped<LoginUseCase>();
    builder.Services.AddScoped<LoginRequestPresenterMapper>();
    builder.Services.AddScoped<Helpper>();
}
catch (Exception)
{
    Console.WriteLine("[Program.cs] Error al intentar inyectar tus dependencias");
}

// Inject the UtilsJwt and configure the authentication
builder.Services.AddSingleton<UtilsJwt>();

builder.Services.AddAuthentication(config => {
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme; // autenticaci�n predeterminada para la aplicaci�n
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme; // esquema de desaf�o predeterminado para la aplicaci�n
}).AddJwtBearer(config => { // agregar autenticaci�n jwt
    config.RequireHttpsMetadata = true; // requiere que las solicitudes se realicen a trav�s de HTTPS
    config.SaveToken = true; // guardar el token
    config.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters // par�metros de validaci�n del token
    {
        ValidateIssuerSigningKey = true, // validar la clave del emisor
        ValidateIssuer = false, // no validar el emisor
        ValidateAudience = false, // no validar la audiencia
        ValidateLifetime = true, // validar el tiempo de vida
        ClockSkew = TimeSpan.Zero, // tiempo de espera
        IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)), // clave de emisi�n
    };
});

// Configuraci�n de CORS para permitir solicitudes desde localhost:3000
builder.Services.AddCors(options =>
{
    options.AddPolicy("NewPolicy",
        policy => policy.WithOrigins("http://localhost:3000")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});



builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("NewPolicy");
app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
