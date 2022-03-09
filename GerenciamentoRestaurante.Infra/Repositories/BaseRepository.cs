using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Interfaces.Repositories;
using GerenciamentoRestaurante.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoRestaurante.Infra.Repositories;

public class BaseRepository<TId, TEntity> : IBaseRepository<TId, TEntity>
    where TId : struct
    where TEntity : Entity<TId, TEntity>
{
    protected DbContext DbContext { get; }

    protected DbSet<TEntity> DbSet { get; }
    
    public BaseRepository(Context dbContext)
    {
        DbSet = dbContext.Set<TEntity>();
        DbContext = dbContext;
    }
    
    public async Task AdicionarLoteAsync(IEnumerable<TEntity> objs)
    {
        await DbSet.AddRangeAsync(objs);
    }

    public async Task AdicionarAsync(TEntity obj)
    {
        await DbSet.AddAsync(obj);
    }

    public async Task<IEnumerable<TEntity>> ObterAsync()
    {
        return await DbSet.ToListAsync();
    }

    public async Task<TEntity?> ObterPorIdAsync(TId id)
    {
        return await DbSet.SingleOrDefaultAsync(e => e.Id.Equals(id));
    }

    public void Remover(TEntity obj)
    {
        DbSet.Remove(obj);
    }

    public void Atualizar(TEntity obj)
    {
        DbSet.Update(obj);
    }

    public async Task SalvarAsync()
    {
        await DbContext.SaveChangesAsync();
    }
}
