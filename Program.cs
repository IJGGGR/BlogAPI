using BlogAPI.Services;
using BlogAPI.Services.Context;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddScoped<SBlogItem>();
builder.Services.AddScoped<SPassword>();
builder.Services.AddScoped<SUser>();

var constr = builder.Configuration.GetConnectionString("MyBlogString2");
builder.Services.AddDbContext<AppDbCtx>(o => o.UseSqlServer(constr));

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

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
