using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Interfaces.Repositories;
using GerenciamentoRestaurante.Infra.Data;

namespace GerenciamentoRestaurante.Infra.Repositories;

public class ItemCardapioRepository : BaseRepository<int, ItemCardapio>, IItemCardapioRepository
{
    public ItemCardapioRepository(Context dbContext) : base(dbContext)
    {
    }
}
