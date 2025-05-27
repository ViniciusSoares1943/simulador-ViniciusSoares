using Microsoft.EntityFrameworkCore;
using SimuladorCredito.Api.Data.Seed;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("SimuladorCredito");

            modelBuilder.Entity<Produto>(x =>
            {
                x.HasData(ProdutoSeed.ObterProdutos());
            });

            modelBuilder.Entity<Segmento>(x =>
            {
                x.HasData(SegmentoSeed.ObterSegmentos());
                x.Property(x => x.RendaMinima).HasPrecision(18, 2);
                x.Property(x => x.RendaMaxima).HasPrecision(18, 2);
            });

            modelBuilder.Entity<TaxaCredito>(x =>
            {
                x.HasData(TaxaCreditoSeed.ObterTaxasCredito());
                x.Property(x => x.Taxa).HasPrecision(18, 4);

                x.HasOne(x => x.Produto).WithMany().HasForeignKey(x => x.ProdutoId);
                x.HasOne(x => x.Segmento).WithMany().HasForeignKey(x => x.SegmentoId);

            });
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Segmento> Segmentos { get; set; }
        public DbSet<TaxaCredito> TaxasCredito { get; set; }
    }
}
