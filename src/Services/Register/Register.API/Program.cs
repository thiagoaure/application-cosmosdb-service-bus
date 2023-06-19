using AutoMapper;
using Processor.API.DataContext;
using Register.API.Extensions;
using Register.API.Filters;
using Register.API.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddCustomServices();
builder.Services.AddCustomRepositories();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
builder.Services.AddCustomFilters();

//builder.Services.AddSingleton(typeof(AutoMapperProfiles));

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
