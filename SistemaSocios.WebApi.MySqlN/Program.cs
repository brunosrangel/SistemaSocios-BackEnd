using Microsoft.EntityFrameworkCore;
using SistemaSocios.Db.Mysql.settings;
using Xis.Generic.DataAccess.Repository;
using Xis.Generic.DataAccess.Service;

var builder = WebApplication.CreateBuilder(args);
var environment = builder.Environment;
var config = new ConfigurationBuilder()
.SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .Build();
// Configurar o serviço de CORS
builder.Services.AddCors();

// Configurar as opções do token
var tokenOptions = new TokenOptions
{
    SecretKey = config["Token:SecretKey"],
    Issuer = config["Token:Issuer"],
    Audience = config["Token:Audience"],
    AccessTokenExpirationMinutes = Convert.ToInt32(config["Token:AccessTokenExpirationMinutes"]),
    RefreshTokenExpirationMinutes = Convert.ToInt32(config["Token:RefreshTokenExpirationMinutes"])
};
builder.Services.AddSingleton(tokenOptions);

var _mySqlOptions = new MySqlOptions
{
    ConnectionString = config["MySqlConfigs:ConnectionString"]
};
builder.Services.AddSingleton(_mySqlOptions);

// Registre o serviço de token com a interface
builder.Services.AddScoped<ITokenService, TokenService>();

// Adicione o contexto do banco de dados como um serviço

//Registrando as Interfaces de Servicos Genericos

builder.Services.AddScoped(typeof(IGenericService<>), typeof(GenericService<>));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddDbContext<DbMySqlContext>(options =>
    options.UseMySql(_mySqlOptions.ConnectionString, ServerVersion.AutoDetect(_mySqlOptions.ConnectionString),
                    b => b.MigrationsAssembly("SistemaSocios.WebApi.MySql")));

builder.Services.AddScoped<DbContext>(provider => provider.GetService<DbMySqlContext>());

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();