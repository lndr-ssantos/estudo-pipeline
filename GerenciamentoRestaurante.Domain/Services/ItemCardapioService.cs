using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Interfaces.Repositories;
using GerenciamentoRestaurante.Domain.Interfaces.Services;
using GerenciamentoRestaurante.Domain.ViewModels;

namespace GerenciamentoRestaurante.Domain.Services;

public class ItemCardapioService : IItemCardapioService
{
    private readonly IItemCardapioRepository _itemCardapioRepository;

    public ItemCardapioService(IItemCardapioRepository itemCardapioRepository)
    {
        _itemCardapioRepository = itemCardapioRepository;
    }

    public async Task<ItemCardapioViewModel> Adicionar(ItemCardapioDto itemCardapioDto)
    {
        var novoItem = new ItemCardapio(itemCardapioDto);

        await _itemCardapioRepository.AdicionarAsync(novoItem);
        await _itemCardapioRepository.SalvarAsync();

        return new ItemCardapioViewModel(novoItem);
    }

    public async Task<ItemCardapioViewModel> Atualizar(int id, ItemCardapioDto itemCardapioDto)
    {
        var itemCardapio = await _itemCardapioRepository.ObterPorIdAsync(id);

        if (itemCardapio == null)
        {
            throw new Exception("Item Cardapio não encontrado");
        }

        itemCardapio.Atualizar(itemCardapioDto);

        _itemCardapioRepository.Atualizar(itemCardapio);
        await _itemCardapioRepository.SalvarAsync();

        return new ItemCardapioViewModel(itemCardapio);
    }

    public async Task<IList<ItemCardapioViewModel>> Obter()
    {
        var itensCardapio = await _itemCardapioRepository.ObterAsync();

        return itensCardapio.Select(cardapio => new ItemCardapioViewModel(cardapio)).ToList();
    }

    public async Task<ItemCardapioViewModel> Obter(int id)
    {
        var itemCardapio = await _itemCardapioRepository.ObterPorIdAsync(id);

        if (itemCardapio == null)
        {
            throw new Exception("Item Cardapio não encontrado");
        }

        return new ItemCardapioViewModel(itemCardapio);
    }

    public async Task<bool> Remover(int id)
    {
        var itemCardapio = await _itemCardapioRepository.ObterPorIdAsync(id);

        if (itemCardapio == null)
        {
            throw new Exception("Item Cardapio não encontrado");
        }

        _itemCardapioRepository.Remover(itemCardapio);
        await _itemCardapioRepository.SalvarAsync();

        return true;
    }
}
