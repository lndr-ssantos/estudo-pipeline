using GerenciamentoRestaurante.Domain.Entities;

namespace GerenciamentoRestaurante.Domain.ViewModels;

public class PedidoViewModel
{
    public PedidoViewModel(Pedido pedido)
    {
        Mesa = pedido.Mesa;
        GarcomId = pedido.GarcomId;
        PedidoItens = pedido.PedidoItens.Select(pedidoItem => new PedidoItemViewModel(pedidoItem)).ToList();
    }

    public string Mesa { get; set; }
    public int GarcomId { get; set; }
    public List<PedidoItemViewModel> PedidoItens { get; set; }
}