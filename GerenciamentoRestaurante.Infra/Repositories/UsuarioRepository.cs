using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Interfaces.Repositories;
using GerenciamentoRestaurante.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoRestaurante.Infra.Repositories;

public class UsuarioRepository : BaseRepository<int, Usuario>, IUsuarioRepository
{
    public UsuarioRepository(Context dbContext) : base(dbContext)
    {
    }

    public async Task<Usuario> ObterPorLogin(string login)
    {
        return await DbSet
            .Include(usuario => usuario.Pessoa)
            .Where(usuario => usuario.Login == login)
            .SingleOrDefaultAsync();
    }
}