using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.ViewModels;

namespace GerenciamentoRestaurante.Domain.Interfaces.Services;

public interface IJwtService
{
    AccessTokenViewModel GerarToken(Usuario usuario);
}