namespace GerenciamentoRestaurante.Domain.ViewModels;

public class AccessTokenViewModel
{
    public AccessTokenViewModel(string token, string tokenType, string expiration)
    {
        Token = token;
        TokenType = tokenType;
        ExpiresIn = expiration;
    }

    public string Token { get; set; }
    public string TokenType { get; set; }
    public string ExpiresIn { get; set; }
}