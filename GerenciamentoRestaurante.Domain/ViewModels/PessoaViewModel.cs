using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Enums;

namespace GerenciamentoRestaurante.Domain.ViewModels;

public class PessoaViewModel
{
    public PessoaViewModel(Pessoa pessoa)
    {
        Id = pessoa.Id;
        Nome = pessoa.Nome;
        Tipo = pessoa.Tipo;
        Usuario = new UsuarioViewModel(pessoa.Usuario!);
    }

    public int Id { get; set; }
    public string Nome { get; set; }
    public TipoPessoaEnum Tipo { get; set; }
    public UsuarioViewModel Usuario { get; set; }
}
