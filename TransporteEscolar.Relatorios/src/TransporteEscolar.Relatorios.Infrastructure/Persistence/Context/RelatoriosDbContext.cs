using Microsoft.EntityFrameworkCore;
using TransporteEscolar.Relatorios.Domain.Entities;

namespace TransporteEscolar.Relatorios.Infrastructure.Persistence.Context;

public class RelatoriosDbContext : DbContext
{
    public RelatoriosDbContext(DbContextOptions<RelatoriosDbContext> options)
        : base(options)
    {
    }

    public DbSet<AlunoSnapshot> Alunos => Set<AlunoSnapshot>();
    public DbSet<PresencaHistorica> PresencasHistoricas => Set<PresencaHistorica>();
    public DbSet<RotaHistorica> RotasHistoricas => Set<RotaHistorica>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlunoSnapshot>(entity =>
        {
            entity.ToTable("alunos_snapshot");
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Nome).HasMaxLength(200).IsRequired();
        });

        modelBuilder.Entity<PresencaHistorica>(entity =>
        {
            entity.ToTable("presencas_historicas");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Data).IsRequired();
            entity.Property(x => x.EnderecoUtilizado).HasMaxLength(500);

            entity.HasOne(x => x.Aluno)
                .WithMany()
                .HasForeignKey(x => x.AlunoId);
        });

        modelBuilder.Entity<RotaHistorica>(entity =>
        {
            entity.ToTable("rotas_historicas");
            entity.HasKey(x => x.Id);

            entity.Property(x => x.Data).IsRequired();
            entity.Property(x => x.DistanciaKm).HasPrecision(10, 2);
        });
    }
}