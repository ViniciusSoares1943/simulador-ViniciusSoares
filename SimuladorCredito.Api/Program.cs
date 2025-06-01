using Microsoft.EntityFrameworkCore;
using NLog.Web;
using SimuladorCredito.Api.Data;
using SimuladorCredito.Api.Repositorios;
using SimuladorCredito.Api.Repositorios.Interfaces;
using SimuladorCredito.Api.Servicos;
using SimuladorCredito.Api.Servicos.Interfaces;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Services
builder.Services.AddScoped<IProdutoRepositorio, ProdutoRepositorio>();
builder.Services.AddScoped<ISegmentoRepositorio, SegmentoRepositorio>();
builder.Services.AddScoped<ITaxaCreditoRepositorio, TaxaCreditoRepositorio>();

builder.Services.AddScoped<IProdutoServico, ProdutoServico>();
builder.Services.AddScoped<ISegmentoServico, SegmentoServico>();
builder.Services.AddScoped<ITaxaCreditoServico, TaxaCreditoServico>();

builder.Services.AddDbContext<DbContextClass>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SicoobDb")));

builder.Logging.ClearProviders();
builder.Logging.SetMinimumLevel(LogLevel.Trace);
builder.Host.UseNLog();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var app = builder.Build();

// Executa as migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DbContextClass>();
    db.Database.Migrate();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
