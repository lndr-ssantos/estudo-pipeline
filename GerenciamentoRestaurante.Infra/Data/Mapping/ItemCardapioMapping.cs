using GerenciamentoRestaurante.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoRestaurante.Infra.Data.Mapping;

public class ItemCardapioMapping : IEntityTypeConfiguration<ItemCardapio>
{
    public void Configure(EntityTypeBuilder<ItemCardapio> builder)
    {
        builder.HasKey(p => p.Id);
        builder.ToTable("ItensCardapio");

        builder.Property(p => p.Nome).HasMaxLength(30).IsRequired();
        builder.Property(p => p.Descricao).HasMaxLength(255).IsRequired();
        builder.Property(p => p.ValorUnidade).HasColumnType("decimal(4,2)").IsRequired();
        builder.Property(p => p.Tipo).IsRequired(); //TODO Adicionar conversão
    }
}
