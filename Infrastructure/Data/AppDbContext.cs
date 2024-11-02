using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace API_Gabini.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasKey(u => u.ID_Usuario);
                entity.Property(u => u.Username).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Nome).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Sobrenome).IsRequired().HasMaxLength(255);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(255);
                entity.HasIndex(u => u.Email).IsUnique();
                entity.Property(u => u.SenhaHash).IsRequired().HasMaxLength(255);
                entity.Property(u => u.CPF).IsRequired().HasMaxLength(14);
                entity.HasIndex(u => u.CPF).IsUnique();
                entity.Property(u => u.Data_Registro).HasDefaultValueSql("CURRENT_TIMESTAMP");
                entity.Property(u => u.Genero).HasConversion<string>();
            });

            modelBuilder.Entity<Endereco>(entity =>
            {
                entity.HasKey(e => e.ID_Endereco);
                entity.Property(e => e.Tipo_Endereco).HasConversion<string>().IsRequired();
                entity.Property(e => e.Rua).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Bairro).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Cidade).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Estado).IsRequired().HasMaxLength(2);
                entity.Property(e => e.CEP).IsRequired().HasMaxLength(10);
                entity.HasOne<Usuario>().WithMany(u => u.Enderecos).HasForeignKey(e => e.ID_Usuario)
                      .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
