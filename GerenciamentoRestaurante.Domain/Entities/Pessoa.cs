using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.Enums;

namespace GerenciamentoRestaurante.Domain.Entities;

public class Pessoa : Entity<int, Pessoa>
{
    public Pessoa()
    {
    }

    public Pessoa(PessoaDto pessoaDto)
    {
        Nome = pessoaDto.Nome;
        Tipo = pessoaDto.Tipo;
        Usuario = new Usuario(pessoaDto.Usuario);
    }

    public string Nome { get; set; }
    public TipoPessoaEnum Tipo { get; set; }
    public Usuario Usuario { get; set; }
    public List<Pedido> Pedidos { get; set; }

    public void Atualizar(PessoaDto pessoaDto)
    {
        Nome = pessoaDto.Nome;
        Tipo = pessoaDto.Tipo;
    }
}
