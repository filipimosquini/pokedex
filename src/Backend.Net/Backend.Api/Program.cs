using Backend.Api.Configurations;
using Backend.CrossCutting.Sections;
using Backend.Infra.Configurations;
using Backend.Ioc.Injectors;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration
    .SetBasePath(builder.Environment.ContentRootPath)
    .AddJsonFile("appsettings.json", true, true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", true, true)
    .AddEnvironmentVariables()
    .Build();

Console.WriteLine(builder.Environment.EnvironmentName);

// Add serilog configurations
SerilogSetup.ConfigureSerilog(builder.Configuration);

builder.Host.UsingSerilog();

// Add services to the container.

var pokeapiSection = builder.Configuration.GetSection("Pokeapi");
builder.Services.Configure<Pokeapi>(pokeapiSection);

builder.Services
    .AddGatewaysInjector()
    .AddDbContextInjector(builder.Configuration)
    .AddRepositoriesInjector()
    .AddServicesInjector()
    .AddApplicationServicesInjector()
    .AddValidatorsInjector();

builder.Services
    .AddingHttpClient()
    .AddingCors()
    .AddingResponseCompression()
    .AddingSwagger();

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddHealthChecks();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHealthChecks("/status");

app.MigrateDatabase();

app.UsingSwagger();

app.UseResponseCompression();
app.UseHttpsRedirection();

app.UseRouting();
app.UseCors(x =>
    x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

app.UsingSerilogRequestLogging();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
