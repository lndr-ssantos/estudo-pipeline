using System.Security.Claims;
using System.Text;
using GerenciamentoRestaurante.Domain.Interfaces.Repositories;
using GerenciamentoRestaurante.Domain.Interfaces.Services;
using GerenciamentoRestaurante.Domain.Services;
using GerenciamentoRestaurante.Infra.Data;
using GerenciamentoRestaurante.Infra.Repositories;
using GerenciamentoRestaurante.Shared.Options;
using GerenciamentoRestaurante.Shared.Resources;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace GerenciamentoRestaurante.Infra.IoC;

public static class IoCExtensions
{
    public static IServiceCollection AddDbContext(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DbConnection");
        var version = ServerVersion.Parse("8.0.28-mysql");
        
        services.AddDbContext<Context>(options => options.UseMySql(connectionString, version,
            x => x.MigrationsHistoryTable("_MigrationHistory")));

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddTransient<IPessoaService, PessoaService>();
        services.AddTransient<IItemCardapioService, ItemCardapioService>();
        services.AddTransient<IPedidoService, PedidoService>();
        services.AddTransient<IJwtService, JwtService>();
        services.AddTransient<IAuthenticationService, AuthenticationService>();

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IPessoaRepository, PessoaRepository>();
        services.AddTransient<IItemCardapioRepository, ItemCardapioRepository>();
        services.AddTransient<IPedidoRepository, PedidoRepository>();
        services.AddTransient<IUsuarioRepository, UsuarioRepository>();
        
        return services;
    }
    
    public static IServiceCollection AddJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
    {
        var secret = configuration.GetSection("JwtConfiguration").GetValue<string>("Secret");
        var issuer = configuration.GetSection("JwtConfiguration").GetValue<string>("Issuer");
        var audience = configuration.GetSection("JwtConfiguration").GetValue<string>("Audience");

        var key = Encoding.ASCII.GetBytes(secret);

        services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    // RequireExpirationTime = true,
                    // ValidateLifetime = true,
                    // ClockSkew = new TimeSpan(0, 3, 0),
                    ValidIssuer = issuer,
                    ValidAudience = audience
                };
            });

        return services;
    }

    public static void AddAuthorizationPolicies(this IServiceCollection services)
    {
        services.AddAuthorization(options =>
        {
            options.AddPolicy(StringConstants.JwtAdministrador, policy =>
            {
                policy.RequireClaim(ClaimTypes.Actor, StringConstants.JwtAdministrador);
                policy.RequireClaim(ClaimTypes.Hash);
                policy.RequireRole(StringConstants.JwtGarcom);
            });

            options.AddPolicy(StringConstants.JwtGarcom, policy =>
            {
                policy.RequireClaim(ClaimTypes.Actor, StringConstants.JwtGarcom);
                policy.RequireClaim(ClaimTypes.Hash);
                policy.RequireRole(StringConstants.JwtGarcom, StringConstants.JwtAdministrador);
            });

            options.FallbackPolicy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();
        });
    }

    public static void ConfigureOptions(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<JwtOptions>(configuration.GetSection("JwtConfiguration"));
    }
}
