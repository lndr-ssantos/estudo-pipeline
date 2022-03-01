using GerenciamentoRestaurante.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoRestaurante.Infra.Data.Mapping;

public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> builder)
    {
        builder.HasKey(p => p.Id);
        builder.ToTable("Usuarios");

        builder.Property(p => p.Login).HasMaxLength(6).IsRequired();
        builder.Property(p => p.Senha).HasMaxLength(15).IsRequired();
        builder.Property(p => p.Ativo).IsRequired();
    }
}
