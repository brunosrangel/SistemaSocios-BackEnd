using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MongoDB.Driver;

var builder = WebApplication.CreateBuilder(args);

// Configurar a conex�o com o MongoDB
var connectionString = builder.Configuration.GetConnectionString("MongoDB");
var mongoClient = new MongoClient(connectionString);
var database = mongoClient.GetDatabase("NomeDoSeuBancoDeDados");

// Registrar o cliente do MongoDB para inje��o de depend�ncia
builder.Services.AddSingleton<IMongoClient>(mongoClient);
builder.Services.AddSingleton(database);

// Registrar a interface IRepository e suas implementa��es necess�rias
builder.Services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));

var app = builder.Build();

// Configura��es do aplicativo
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
