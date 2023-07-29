using Api.Dodai.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Dodai.Context
{
    public class DodaiDbContext : DbContext
    {
        public DodaiDbContext(DbContextOptions<DodaiDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>().ToTable("TB_PRODUTO");

            //Definir atributos e relacionamentos
            modelBuilder.Entity<Produto>(entity =>
            {
                entity.HasKey(e => e.Id_Produto);
                entity.Property(e => e.Id_Produto).ValueGeneratedOnAdd();
            });

            base.OnModelCreating(modelBuilder);

        }
    }
}
