using ApiLegalizationSystem.Data.Models;
using ApiLegalizationSystem.Domain.Mappers;
using ApiLegalizationSystem.Domain.UseCases;
using ApiLegalizationSystem.Domain.Utils;
using ApiLegalizationSystem.Presenter.Mappers;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Inject the LegalizationSystemContext
builder.Services.AddDbContext<LegalizationSystemContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("QuerySQLSetting"));
});

// Inject the UserDomainMapper, CreateUserUseCase and Helpper
try {
    builder.Services.AddScoped<UserDomainMapper>();
    builder.Services.AddScoped<UserPresenterMapper>();
    builder.Services.AddScoped<CreateUserUseCase>();
    builder.Services.AddScoped<Helpper>();
}
catch (Exception)
{
    Console.WriteLine("[Program.cs] Error al intentar inyectar tus dependencias");
}



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

app.UseAuthorization();

app.MapControllers();

app.Run();
