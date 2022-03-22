using GerenciamentoRestaurante.Domain.Enums;

namespace GerenciamentoRestaurante.Domain.Dtos;

public class ItemCardapioDto
{
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal ValorUnidade { get; set; }
    public TipoItemCardapioEnum Tipo { get; set; }
}
