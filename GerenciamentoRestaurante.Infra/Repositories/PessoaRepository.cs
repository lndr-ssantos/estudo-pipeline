using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Enums;
using GerenciamentoRestaurante.Domain.Interfaces.Repositories;
using GerenciamentoRestaurante.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoRestaurante.Infra.Repositories;

public class PessoaRepository : BaseRepository<int, Pessoa>, IPessoaRepository
{
    public PessoaRepository(Context dbContext) : base(dbContext)
    {
    }
}
