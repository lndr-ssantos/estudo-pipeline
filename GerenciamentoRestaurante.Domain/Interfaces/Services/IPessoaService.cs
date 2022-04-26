using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.ViewModels;

namespace GerenciamentoRestaurante.Domain.Interfaces.Services;

public interface IPessoaService : IBaseService< int, PessoaDto, PessoaViewModel>
{
    Task AdicionarUsuarioPadraoSistema(PessoaDto pessoaDto);
}
