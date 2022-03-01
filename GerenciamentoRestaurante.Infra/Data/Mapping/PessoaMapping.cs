using GerenciamentoRestaurante.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoRestaurante.Infra.Data.Mapping;

public class PessoaMapping : IEntityTypeConfiguration<Pessoa>
{
    public void Configure(EntityTypeBuilder<Pessoa> builder)
    {
        builder.HasKey(p => p.Id);
        builder.ToTable("Pessoas");

        builder.Property(p => p.Nome).HasMaxLength(150).IsRequired();
        builder.Property(p => p.Tipo).HasMaxLength(5).IsRequired(); //TODO Adicionar conversão

        builder.HasOne(p => p.Usuario)
            .WithOne(u => u.Pessoa)
            .HasForeignKey<Usuario>(p => p.PessoaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
