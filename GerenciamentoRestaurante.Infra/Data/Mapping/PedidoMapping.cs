using GerenciamentoRestaurante.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GerenciamentoRestaurante.Infra.Data.Mapping;

public class PedidoMapping : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.HasKey(p => p.Id);
        builder.ToTable("Pedidos");

        builder.Property(p => p.Valor).HasColumnType("decimal(5,2)");
        builder.Property(p => p.ValorGorjeta).HasColumnType("decimal(5,2)");
        builder.Property(p => p.DataInicio).IsRequired();
        builder.Property(p => p.DataFim);
        builder.Property(p => p.Mesa).HasMaxLength(2);

        builder.HasOne(pedido => pedido.Garcom)
            .WithMany(pessoa => pessoa.Pedidos)
            .HasForeignKey(pedido => pedido.GarcomId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasMany(pedido => pedido.PedidoItens)
            .WithOne(pedidoItem => pedidoItem.Pedido)
            .HasForeignKey(pedidoItem => pedidoItem.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
