using GerenciamentoRestaurante.Domain.Entities;

namespace GerenciamentoRestaurante.Domain.Interfaces.Repositories;

public interface IBaseRepository<TId, TEntity>
    where TId : struct
    where TEntity : Entity<TId, TEntity>
{
    Task AdicionarLoteAsync(IEnumerable<TEntity> objs);
    Task AdicionarAsync(TEntity obj);
    Task<IEnumerable<TEntity>> ObterAsync();
    Task<TEntity> ObterPorIdAsync(TId id);
    void Remover(TEntity obj);
    void Atualizar(TEntity obj);
    Task SalvarAsync();

}
