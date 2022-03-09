using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.Enums;

namespace GerenciamentoRestaurante.Domain.Entities;

public class ItemCardapio : Entity<int, ItemCardapio>
{
    public ItemCardapio()
    {
    }
    
    public ItemCardapio(ItemCardapioDto itemCardapioDto)
    {
        Nome = itemCardapioDto.Nome;
        Descricao = itemCardapioDto.Descricao;
        ValorUnidade = itemCardapioDto.ValorUnidade;
        Tipo = itemCardapioDto.Tipo;
    }

    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal ValorUnidade { get; set; }
    public TipoItemCardapioEnum Tipo { get; set; }
    public ICollection<PedidoItem> PedidoItens { get; set; }

    public void Atualizar(ItemCardapioDto itemCardapioDto)
    {
        Nome = itemCardapioDto.Nome;
        Descricao = itemCardapioDto.Descricao;
        ValorUnidade = itemCardapioDto.ValorUnidade;
        Tipo = itemCardapioDto.Tipo;
    }
}
