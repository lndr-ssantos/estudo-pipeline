using GerenciamentoRestaurante.Domain.Entities;

namespace GerenciamentoRestaurante.Domain.ViewModels;

public class PedidoItemViewModel
{
    public PedidoItemViewModel(PedidoItem pedidoItem)
    {
        Nome = pedidoItem.ItemCardapio.Nome;
        Quantidade = pedidoItem.Quantidade;
    }

    public string Nome { get; set; }
    public ushort Quantidade { get; set; }
}