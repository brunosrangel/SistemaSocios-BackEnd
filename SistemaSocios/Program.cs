using SistemaSocio.Service.interfaces;
using SistemaSocio.Service.Services;
using SistemaSocios.Db.MongoDb;
using SistemaSocios.Db.MongoDb.Usuario;
using SistemaSocios.Db.Mysql.settings;
using SistemaSocios.Db.Servicos;

var builder = WebApplication.CreateBuilder(args);

// Configurar o servi�o de CORS
builder.Services.AddCors();

// Configurar a leitura do arquivo appsettings.json com base no ambiente
var environment = builder.Environment;
var config = new ConfigurationBuilder()
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .Build();

// Configurar as op��es do token
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

// Registre o servi�o de token com a interface
builder.Services.AddScoped<ITokenService, TokenService>();

// Carregar as configura��es do MongoDB do arquivo appsettings.json
var mongoDbSettings = config.GetSection("MongoDBSettings").Get<MongoDbSettings>();

// Registre o servi�o de token com a interface
builder.Services.AddScoped<ITokenService, TokenService>();

// Registrar IMongoDbSettings no cont�iner de servi�os
builder.Services.AddSingleton<IMongoDbSettings>(mongoDbSettings);

// Registro de IEntityService<EntidadeModel> e sua implementa��o EntityService<EntidadeModel>
//// Registro do servi�o EntityService<EntidadeModel> e do reposit�rio MongoRepository<EntidadeModel>
//builder.Services.AddScoped<IEntityService<EntidadeModelMongoDb>, EntityService<EntidadeModelMongoDb>>();
//builder.Services.AddScoped<IMongoRepository<EntidadeModelMongoDb>, MongoRepository<EntidadeModelMongoDb>>();
//builder.Services.AddScoped<IEntityService<UsuarioModelMongoDb>, EntityService<UsuarioModelMongoDb>>();
//builder.Services.AddScoped<IMongoRepository<UsuarioModelMongoDb>, MongoRepository<UsuarioModelMongoDb>>();

////Classes Customizadas
//builder.Services.AddScoped<IUserService<UsuarioModelMongoDb>, UserService<UsuarioModelMongoDb>>();
//builder.Services.AddScoped<IUsuarioMongoRepository<UsuarioModelMongoDb>, UsuarioMongoRepository<UsuarioModelMongoDb>>();






builder.Services.AddControllers();

// Dentro do m�todo de configura��o dos servi�os da sua aplica��o
builder.Services.AddLogging(builder => builder.AddConsole());

// Ou, se preferir, adicione um logger espec�fico para um tipo de classe
builder.Services.AddLogging(loggingBuilder =>
{
    loggingBuilder.AddConsole();
    loggingBuilder.AddDebug();
});

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