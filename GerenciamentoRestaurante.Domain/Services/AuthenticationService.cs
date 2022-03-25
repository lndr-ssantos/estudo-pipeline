using GerenciamentoRestaurante.Domain.Dtos;
using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Interfaces.Repositories;
using GerenciamentoRestaurante.Domain.Interfaces.Services;
using GerenciamentoRestaurante.Domain.ViewModels;
using GerenciamentoRestaurante.Shared.Helpers;

namespace GerenciamentoRestaurante.Domain.Services;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly IJwtService _jwtService;

    public AuthenticationService(IUsuarioRepository usuarioRepository, IJwtService jwtService)
    {
        _usuarioRepository = usuarioRepository;
        _jwtService = jwtService;
    }

    public async Task<AccessTokenViewModel> Autenticar(LoginDto loginDto)
    {
        var usuario = await ObterUsuario(loginDto.Login);

        var senhaCriptografada = SecurityHelper.HashSenha(loginDto.Senha, usuario.Salt);

        if (senhaCriptografada != usuario.Senha)
        {
            throw new Exception("Senha inválida");
        }

        return _jwtService.GerarToken(usuario);
    }

    public async Task<bool> ResetarSenha(LoginDto loginDto)
    {
        var usuario = await ObterUsuario(loginDto.Login);

        var (senha, salt) = SecurityHelper.CriptografarSenha(loginDto.Senha);
        usuario.AdicionarSenha(senha, salt);
        
        _usuarioRepository.Atualizar(usuario);
        await _usuarioRepository.SalvarAsync();

        return true;
    }

    private async Task<Usuario> ObterUsuario(string login)
    {
        var usuario = await _usuarioRepository.ObterPorLogin(login);

        if (usuario == null)
        {
            throw new Exception("Usuário não encontrado");
        }

        return usuario;
    }
}