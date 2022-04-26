using GerenciamentoRestaurante.Domain.Dtos;

namespace GerenciamentoRestaurante.Domain.Entities;

public class Usuario : Entity<int, Usuario>
{
    public Usuario()
    {
    }

    public Usuario(UsuarioDto usuarioDto)
    {
        Login = usuarioDto.Login;
        Ativo = true;
    }

    public int PessoaId { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public string Salt { get; set; }
    public bool Ativo { get; set; }
    public Pessoa Pessoa { get; set; }

    public void AdicionarSenha(string senha, string salt)
    {
        Senha = senha;
        Salt = salt;
    }
}
