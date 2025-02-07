using KoperasiTenteraApi.Infrastructure;
using KoperasiTenteraApi.Application;
using KoperasiTenteraApi.API.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();

builder.Services.AddDbContext(builder.Configuration);
builder.Services.AddApplicationServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseMiddleware<ExceptionMiddleware>();
app.MapControllers();
app.InitializeDatabase();

app.Run();