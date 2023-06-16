using Microsoft.Azure.Cosmos;
using Processor.API.DataContext;
using Processor.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<AppDbContext>();

//builder.Services.AddSingleton(x => new CosmosClient("AccountEndpoint=https://my-cosmos-nosql.documents.azure.com:443/;AccountKey=hejHenqyJT5DioSrVNL6S8ozBCfN7V6U50jheEpsdxhEqbZbHfi3FKlg89hFKltBpBu9QCdehqocACDbSJcVAQ==;"));
builder.Services.AddTransient<ICustomerRespository, CustomerRepository>();
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
