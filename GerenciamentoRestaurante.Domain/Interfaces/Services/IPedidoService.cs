using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.ViewModels;

namespace GerenciamentoRestaurante.Domain.Interfaces.Services;

public interface IPedidoService : IBaseService<int, PedidoDto, PedidoViewModel>
{
}