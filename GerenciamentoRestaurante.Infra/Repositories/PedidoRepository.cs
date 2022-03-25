using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Interfaces.Repositories;
using GerenciamentoRestaurante.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoRestaurante.Infra.Repositories;

public class PedidoRepository : BaseRepository<int, Pedido>, IPedidoRepository
{
    public PedidoRepository(Context dbContext) : base(dbContext)
    {
    }

    public override async Task<IEnumerable<Pedido>> ObterAsync()
    {
        return await DbSet
            .Include(pedido => pedido.PedidoItens)
            .ThenInclude(pedidoItem => pedidoItem.ItemCardapio)
            .ToListAsync();
    }
}