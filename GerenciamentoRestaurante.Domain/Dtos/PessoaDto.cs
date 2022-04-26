using GerenciamentoRestaurante.Domain.Enums;

namespace GerenciamentoRestaurante.Domain.Dtos;

public class PessoaDto
{
    public string Nome { get; set; }
    public TipoPessoaEnum Tipo { get; set; }
    public UsuarioDto Usuario { get; set; }
}
