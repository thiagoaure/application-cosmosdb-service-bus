using Processor.API.DataContext;
using Processor.API.ExtensionHelpers;
using Processor.API.Extensions;
using Processor.API.Helpers;
using Processor.API.Interfaces;
using Processor.API.ServiceBus;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();

builder.Services.AddControllers();
builder.Services.AddCustomProcessorRepositories();
builder.Services.AddCustomProcessorServices();
builder.Services.AddAutoMapper(typeof(AutoMapperProfiles));
//await builder.Services.AddCustomServiceBusAsync();
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
