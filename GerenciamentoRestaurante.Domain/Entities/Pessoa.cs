using GerenciamentoRestaurante.Domain.Enums;

namespace GerenciamentoRestaurante.Domain.Entities;

public class Pessoa
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public TipoPessoaEnum Tipo { get; set; }
    public Usuario Usuario { get; set; }
    public ICollection<Pedido> Pedidos { get; set; }
}
