using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Api.Models.Entidades;

namespace SimuladorCredito.Api.Data
{
    public class DbContextClass : DbContext
    {
        private readonly IConfiguration _configuration;

        public DbContextClass(DbContextOptions<DbContextClass> options, IConfiguration configuration) : base(options)
        {
            _configuration = configuration;
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("SimuladorCredito");
        }


        DbSet<Produto> Produtos { get; set; }
        DbSet<Segmento> Segmentos { get; set; }
        DbSet<TaxaCredito> TaxasCredito { get; set; }
    }
}
