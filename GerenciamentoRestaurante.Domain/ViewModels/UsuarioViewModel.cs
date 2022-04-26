using GerenciamentoRestaurante.Domain.Entities;

namespace GerenciamentoRestaurante.Domain.ViewModels;

public class UsuarioViewModel
{
    public UsuarioViewModel(Usuario usuario)
    {
        Id = usuario.Id;
        Login = usuario.Login;
    }

    public int Id { get; set; }
    public string Login { get; set; }
}
