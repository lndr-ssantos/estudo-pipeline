using GerenciamentoRestaurante.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoRestaurante.Infra.Data.Mapping;

public class PedidoItemMapping : IEntityTypeConfiguration<PedidoItem>
{
    public void Configure(EntityTypeBuilder<PedidoItem> builder)
    {
        builder.HasKey(p => new {p.PedidoId, p.ItemId});
        builder.ToTable("PedidosItens");

        builder.Property(p => p.ItemId);
        builder.Property(p => p.PedidoId);
        builder.Property(p => p.Quantidade);

        builder.HasOne(pedidoItem => pedidoItem.ItemCardapio)
            .WithMany(itemCardapio => itemCardapio.PedidoItens)
            .HasForeignKey(pedidoItem => pedidoItem.ItemId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
