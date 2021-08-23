using Microsoft.EntityFrameworkCore;
using SmartCommerce.Domain.Entities;

namespace SmartCommerce.Infra.Data.Context
{
    /// <summary>
    /// Contexto da aplicação
    /// </summary>
    public class SmartCommerceContext : DbContext
    {

        public DbSet<Local> Local { get; set; }
        public DbSet<LocalProduto> LocalProdutos { get; set; }
        public DbSet<Produto> Produto { get; set; }
        public DbSet<Segmento> Segmento { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Login> Login { get; set; }
        public DbSet<Votacao> Votacao { get; set; }

        /// <summary>
        /// Construtor
        /// </summary>
        /// <param name="options">DbContext para injeção</param>
        public SmartCommerceContext(DbContextOptions<SmartCommerceContext> options = null) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Local>()
            //           .HasMany<Produto>(s => s.Produtos)
            //           .WithMany(c => c.Locals)
            //           .Map(cs =>
            //           {
            //               cs.MapLeftKey("LOCALID");
            //               cs.MapRightKey("PRODUTOID");
            //               cs.ToTable("T_Local_Produto");
            //           });

            modelBuilder.Entity<LocalProduto>()
                .HasKey(bc => new { bc.LocalId, bc.ProdutoId });

            modelBuilder.Entity<LocalProduto>()
                .HasOne<Local>(sc => sc.Local)
                .WithMany(s => s.LocalProdutos)
                .HasForeignKey(sc => sc.LocalId);


            modelBuilder.Entity<LocalProduto>()
                .HasOne<Produto>(sc => sc.Produto)
                .WithMany(s => s.LocalProdutos)
                .HasForeignKey(sc => sc.ProdutoId);


        }
    }
}
