using CrossCutting;
using Infrastructure;
using Microsoft.EntityFrameworkCore;
using TesteStef.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.SetupInfrastructure(builder.Configuration);
builder.Services.SetupApplication(builder.Configuration);

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseMiddleware<ApplicationExceptionHandlingMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using var scope = app.Services.CreateScope();
await using var dbContext = scope.ServiceProvider.GetRequiredService<ApiDbContext>();
await dbContext.Database.MigrateAsync();

app.Run();