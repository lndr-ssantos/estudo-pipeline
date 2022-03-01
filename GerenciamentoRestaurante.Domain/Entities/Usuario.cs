namespace GerenciamentoRestaurante.Domain.Entities;

public class Usuario
{
    public int Id { get; set; }
    public int PessoaId { get; set; }
    public string Login { get; set; }
    public string Senha { get; set; }
    public bool Ativo { get; set; }
    public Pessoa Pessoa { get; set; }
    
}
