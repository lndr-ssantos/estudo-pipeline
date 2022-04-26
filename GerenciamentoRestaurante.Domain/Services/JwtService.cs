using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GerenciamentoRestaurante.Domain.Entities;
using GerenciamentoRestaurante.Domain.Enums;
using GerenciamentoRestaurante.Domain.Interfaces.Services;
using GerenciamentoRestaurante.Domain.ViewModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using GerenciamentoRestaurante.Shared.Options;
using GerenciamentoRestaurante.Shared.Resources;

namespace GerenciamentoRestaurante.Domain.Services;

public class JwtService : IJwtService
{
    private readonly JwtOptions _jwtOptions;

    public JwtService(IOptions<JwtOptions> jwtOptions)
    {
        _jwtOptions = jwtOptions.Value;
    }

    public AccessTokenViewModel GerarToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtOptions.Secret);
        var expiration = DateTime.Now.AddMinutes(_jwtOptions.ExpirationInMinutes);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Actor, usuario.Pessoa.Tipo.IsAdministrador() 
                    ? StringConstants.JwtAdministrador
                    : StringConstants.JwtGarcom),
                new Claim(ClaimTypes.Hash, usuario.Id.ToString()),
                new Claim(ClaimTypes.Role, usuario.Pessoa.Tipo.IsAdministrador() 
                    ? StringConstants.JwtGarcom
                    : StringConstants.JwtAdministrador)
            }),
            Issuer = _jwtOptions.Issuer,
            Audience = _jwtOptions.Audience,
            // Expires = expiration.ToUniversalTime(),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);

        return new AccessTokenViewModel(tokenHandler.WriteToken(token), "bearer", expiration.ToString("yyyy-MM-dd HH:mm:ss"));
    }
}
