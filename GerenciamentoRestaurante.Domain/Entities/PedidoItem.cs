namespace GerenciamentoRestaurante.Domain.Entities;

public class PedidoItem 
{
    public int PedidoId { get; set; }
    public int ItemId { get; set; }
    public ushort Quantidade { get; set; }
    public Pedido? Pedido { get; set; }
    public ItemCardapio? ItemCardapio { get; set; }
}
