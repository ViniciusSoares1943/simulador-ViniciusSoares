using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Api.Data;
using SimuladorCredito.Api.Repositorios;
using SimuladorCredito.Api.Repositorios.Interfaces;
using SimuladorCredito.Api.Servicos;
using SimuladorCredito.Api.Servicos.Interfaces;

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

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Executa as migrations automaticamente
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DbContextClass>();
    db.Database.Migrate(); // Aplica as migrations pendentes no banco
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
