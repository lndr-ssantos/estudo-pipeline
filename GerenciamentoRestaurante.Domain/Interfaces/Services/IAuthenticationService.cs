using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.ViewModels;

namespace GerenciamentoRestaurante.Domain.Interfaces.Services;

public interface IAuthenticationService
{
    Task<AccessTokenViewModel> Autenticar(LoginDto loginDto);
    Task<bool> ResetarSenha(LoginDto loginDto);
}