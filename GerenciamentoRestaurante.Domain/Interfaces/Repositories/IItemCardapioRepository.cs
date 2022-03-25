using GerenciamentoRestaurante.Domain.Entities;

namespace GerenciamentoRestaurante.Domain.Interfaces.Repositories;

public interface IItemCardapioRepository : IBaseRepository<int, ItemCardapio>
{
    Task<List<ItemCardapio>> ObterItensPorIdEmLoteAsync(ICollection<int> ids);
}
