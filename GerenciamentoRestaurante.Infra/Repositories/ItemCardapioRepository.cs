using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Interfaces.Repositories;
using GerenciamentoRestaurante.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoRestaurante.Infra.Repositories;

public class ItemCardapioRepository : BaseRepository<int, ItemCardapio>, IItemCardapioRepository
{
    public ItemCardapioRepository(Context dbContext) : base(dbContext)
    {
    }

    public async Task<List<ItemCardapio>> ObterItensPorIdEmLoteAsync(ICollection<int> ids)
    {
        return await DbSet.Where(x => ids.Contains(x.Id)).ToListAsync();
    }
}
