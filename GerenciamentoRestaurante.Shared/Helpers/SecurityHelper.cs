using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace GerenciamentoRestaurante.Shared.Helpers;

public static class SecurityHelper
{
    public static string GerarSalt()
    {
        var saltBytes = new byte[128 / 8];

        RandomNumberGenerator.Create().GetNonZeroBytes(saltBytes);

        return Convert.ToBase64String(saltBytes);
    }

    public static string HashSenha(string senha, string salt)
    {
        var saltBytes = Convert.FromBase64String(salt);

        var hashSenha = KeyDerivation.Pbkdf2(
            senha,
            saltBytes,
            KeyDerivationPrf.HMACSHA256,
            100000,
            256 / 8);

        return Convert.ToBase64String(hashSenha);
    }
}
