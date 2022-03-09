using GerenciamentoRestaurante.Domain.Entities;

namespace GerenciamentoRestaurante.Domain.ViewModels;

public class UsuarioViewModel
{
    public UsuarioViewModel(Usuario usuario)
    {
        Login = usuario.Login;
    }

    public string? Login { get; set; }
}
