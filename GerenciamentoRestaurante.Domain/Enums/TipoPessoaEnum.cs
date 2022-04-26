namespace GerenciamentoRestaurante.Domain.Enums;

public enum TipoPessoaEnum
{
    Garcom,
    Administrador
}

public static class TipoPessoaEnumExtensions {
    public static bool IsAdministrador(this TipoPessoaEnum tipo)
    {
        return tipo == TipoPessoaEnum.Administrador;
    }
}
