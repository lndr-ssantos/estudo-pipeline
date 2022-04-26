using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Interfaces.Repositories;
using GerenciamentoRestaurante.Domain.Interfaces.Services;
using GerenciamentoRestaurante.Domain.ViewModels;

namespace GerenciamentoRestaurante.Domain.Services;

public class PedidoService : IPedidoService
{
    private readonly IPedidoRepository _pedidoRepository;
    private readonly IPessoaRepository _pessoaRepository;
    private readonly IItemCardapioRepository _itemCardapioRepository;

    public PedidoService(IPedidoRepository pedidoRepository, IPessoaRepository pessoaRepository,
        IItemCardapioRepository itemCardapioRepository)
    {
        _pedidoRepository = pedidoRepository;
        _pessoaRepository = pessoaRepository;
        _itemCardapioRepository = itemCardapioRepository;
    }

    public async Task<PedidoViewModel> Adicionar(PedidoDto pedidoDto)
    {
        var garcom = await _pessoaRepository.ObterPorIdAsync(1);
        var novoPedido = new Pedido(garcom, pedidoDto.Mesa);

        await AdicionarItens(pedidoDto, novoPedido);

        await _pedidoRepository.AdicionarAsync(novoPedido);
        await _pedidoRepository.SalvarAsync();

        return new PedidoViewModel(novoPedido);
    }

    private async Task AdicionarItens(PedidoDto pedidoDto, Pedido pedido)
    {
        var itensCardapio =
            await _itemCardapioRepository.ObterItensPorIdEmLoteAsync(pedidoDto.Itens.Select(x => x.Id).ToList());

        if (itensCardapio.Count < pedidoDto.Itens.Count)
        {
            throw new Exception("Algum item está incorreto");
        }

        var pedidoItens =
            (from pedidoItem in pedidoDto.Itens
                let itemCardapio = itensCardapio.Single(x => x.Id == pedidoItem.Id)
                select new PedidoItem(pedido, itemCardapio, pedidoItem.ItemQuantidade)
            ).ToList();

        pedido.AdicionarItens(pedidoItens);
    }


    public async Task<PedidoViewModel> Atualizar(int id, PedidoDto pedidoDto)
    {
        var pedido = await _pedidoRepository.ObterPorIdAsync(id);

        if (pedido == null)
        {
            throw new Exception("Pedido não encontrado");
        }

        await AdicionarItens(pedidoDto, pedido);
        
        _pedidoRepository.Atualizar(pedido);
        await _pedidoRepository.SalvarAsync();

        return new PedidoViewModel(pedido);
    }

    public async Task<IList<PedidoViewModel>> Obter()
    {
        var pedidos = await _pedidoRepository.ObterAsync();

        return pedidos.Select(pedido => new PedidoViewModel(pedido)).ToList();
    }

    public async Task<PedidoViewModel> Obter(int id)
    {
        var pedido = await _pedidoRepository.ObterPorIdAsync(id);
        
        if (pedido == null)
        {
            throw new Exception("Pedido não encontrada");
        }

        return new PedidoViewModel(pedido);
    }

    public async Task<bool> Remover(int id)
    {
        var pedido = await _pedidoRepository.ObterPorIdAsync(id);
        
        if (pedido == null)
        {
            throw new Exception("Pessoa não encontrada");
        }
        
        _pedidoRepository.Remover(pedido);
        await _pedidoRepository.SalvarAsync();

        return true;
    }
}