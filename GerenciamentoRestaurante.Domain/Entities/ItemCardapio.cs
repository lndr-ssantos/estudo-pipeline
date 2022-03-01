using GerenciamentoRestaurante.Domain.Enums;

namespace GerenciamentoRestaurante.Domain.Entities;

public class ItemCardapio
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal ValorUnidade { get; set; }
    public TipoItemCardapioEnum Tipo { get; set; }
    public ICollection<PedidoItem> PedidoItens { get; set; }
}
