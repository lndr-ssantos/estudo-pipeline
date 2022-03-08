namespace GerenciamentoRestaurante.Domain.Entities;

public class Pedido : Entity<int, Pedido>
{
    public int GarcomId { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public decimal? Valor { get; set; }
    public decimal? ValorGorjeta { get; set; }
    public Pessoa? Garcom { get; set; }
    public ICollection<PedidoItem>? PedidoItens { get; set; }

}
