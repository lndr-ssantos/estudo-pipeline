namespace GerenciamentoRestaurante.Domain.Interfaces.Services;

public interface IBaseService<TId, TEntity, TREntity>
    where TId : struct
    where TEntity : class
    where TREntity : class
{
    Task<TREntity> Adicionar(TEntity pessoaDto);
    Task<TREntity> Atualizar(TId id, TEntity pessoaDto);
    Task<IList<TREntity>> Obter();
    Task<TREntity> Obter(TId id);
    Task<bool> Remover(TId id);
}
