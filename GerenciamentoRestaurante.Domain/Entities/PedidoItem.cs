namespace GerenciamentoRestaurante.Domain.Entities;

public class PedidoItem
{
    public PedidoItem()
    {
    }

    public PedidoItem(Pedido pedido, ItemCardapio itemCardapio, ushort quantidade)
    {
        Pedido = pedido;
        ItemCardapio = itemCardapio;
        Quantidade = quantidade;
    }

    public int PedidoId { get; set; }
    public int ItemId { get; set; }
    public ushort Quantidade { get; set; }
    public Pedido Pedido { get; set; }
    public ItemCardapio ItemCardapio { get; set; }
}