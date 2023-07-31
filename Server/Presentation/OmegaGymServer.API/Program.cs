using FluentValidation.AspNetCore;
using OmegaGymServer.API.Filters;
using OmegaGymServer.Application;
using OmegaGymServer.Infrastructure;
using OmegaGymServer.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddApplicationServices(builder.Configuration);
builder.Services.AddInfrastructureService();

builder.Services.AddControllers(options =>
{
    options.Filters.Add<SecuredOperation>();
}).AddFluentValidation();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.WithOrigins("https://omega-gym.com", "http://omega-gym.com", "http://api.omega-gym.com", "https://api.omega-gym.com", "http://localhost:4200", "https://localhost:4200").SetIsOriginAllowedToAllowWildcardSubdomains().AllowAnyHeader().AllowAnyMethod()));


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();

