using MongoDB.Driver;
using SistemaSocios.Core.Model.settings;

var builder = WebApplication.CreateBuilder(args);

// Configurar o serviço de CORS
builder.Services.AddCors();

// Carregar o arquivo appsettings.json em uma instância de IConfiguration
var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
// Desserializar o arquivo em um objeto AppSettings
var appSettings = config.Get<AppSettings>();
//var connectionString = builder.Configuration.GetConnectionString("MongoDBSettings");
var mongoClient = new MongoClient(appSettings.MongoDBSettings.ConnectionString);
var database = mongoClient.GetDatabase(appSettings.MongoDBSettings.DatabaseName);

// Registrar o cliente do MongoDB para injeção de dependência
builder.Services.AddSingleton<IMongoClient>(mongoClient);

// Registrar o banco de dados MongoDB para injeção de dependência
builder.Services.AddSingleton(database);

// Registrar a interface IRepository e suas implementações necessárias
builder.Services.AddScoped(typeof(IRepository<>), typeof(MongoRepository<>));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseDefaultFiles();
app.UseStaticFiles();

app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
    options.RoutePrefix = string.Empty;
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.Use((corsContext, next) =>
    {
        corsContext.Response.Headers["Access-Control-Allow-Origin"] = "*";
        return next.Invoke();
    });
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseCors();

app.MapControllers();

app.MapFallbackToFile("/index.html");

app.Run();
