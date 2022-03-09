using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Interfaces.Repositories;
using GerenciamentoRestaurante.Infra.Data;

namespace GerenciamentoRestaurante.Infra.Repositories;

public class PessoaRepository : BaseRepository<int, Pessoa>, IPessoaRepository
{
    public PessoaRepository(Context dbContext) : base(dbContext)
    {
    }
}
