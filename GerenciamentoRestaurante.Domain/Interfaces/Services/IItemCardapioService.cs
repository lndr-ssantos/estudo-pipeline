using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.ViewModels;

namespace GerenciamentoRestaurante.Domain.Interfaces.Services;

public interface IItemCardapioService : IBaseService<int, ItemCardapioDto, ItemCardapioViewModel>
{
}
