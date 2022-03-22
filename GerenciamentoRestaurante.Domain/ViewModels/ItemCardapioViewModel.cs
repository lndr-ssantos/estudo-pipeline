using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Enums;

namespace GerenciamentoRestaurante.Domain.ViewModels;

public class ItemCardapioViewModel
{
    public ItemCardapioViewModel(ItemCardapio itemCardapio)
    {
        Id = itemCardapio.Id;
        Nome = itemCardapio.Nome;
        Descricao = itemCardapio.Descricao;
        ValorUnidade = itemCardapio.ValorUnidade;
        Tipo = itemCardapio.Tipo;
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public decimal ValorUnidade { get; set; }
    public TipoItemCardapioEnum Tipo { get; set; }
}
