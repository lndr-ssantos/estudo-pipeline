namespace GerenciamentoRestaurante.Domain.Dtos;

public class PedidoDto
{
    public string Mesa { get; set; }
    public ICollection<PedidoItemDto> Itens { get; set; }
}