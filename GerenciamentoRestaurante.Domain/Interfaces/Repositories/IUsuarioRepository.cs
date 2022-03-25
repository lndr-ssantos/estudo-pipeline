using GerenciamentoRestaurante.Domain.Entities;

namespace GerenciamentoRestaurante.Domain.Interfaces.Repositories;

public interface IUsuarioRepository : IBaseRepository<int, Usuario>
{
    Task<Usuario> ObterPorLogin(string login);
}