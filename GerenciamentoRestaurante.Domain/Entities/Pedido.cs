namespace GerenciamentoRestaurante.Domain.Entities;

public class Pedido : Entity<int, Pedido>
{
    public Pedido()
    {
    }

    public Pedido(Pessoa garcom, string mesa)
    {
        Garcom = garcom;
        Mesa = mesa;
        DataInicio = DateTime.Now;
    }

    public int GarcomId { get; set; }
    public string Mesa { get; set; }
    public DateTime DataInicio { get; set; }
    public DateTime? DataFim { get; set; }
    public decimal? Valor { get; set; }
    public decimal? ValorGorjeta { get; set; }
    public Pessoa Garcom { get; set; }
    public List<PedidoItem> PedidoItens { get; set; }

    public void AdicionarItens(List<PedidoItem> pedidoItens)
    {
        PedidoItens ??= new List<PedidoItem>();
        
        PedidoItens.AddRange(pedidoItens);
    }
}