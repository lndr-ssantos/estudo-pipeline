using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Enums;

namespace GerenciamentoRestaurante.Domain.Interfaces.Repositories;

public interface IPessoaRepository : IBaseRepository<int, Pessoa>
{
    Task<bool> VerificarSePessoaExiste(string nome, TipoPessoaEnum tipoPessoaEnum);
}
