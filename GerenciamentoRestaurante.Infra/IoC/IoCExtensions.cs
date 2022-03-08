using GerenciamentoRestaurante.Domain.Interfaces.Repositories;
using GerenciamentoRestaurante.Domain.Interfaces.Services;
using GerenciamentoRestaurante.Domain.Services;
using GerenciamentoRestaurante.Infra.Data;
using GerenciamentoRestaurante.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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

        return services;
    }

    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddTransient<IPessoaRepository, PessoaRepository>();
        
        return services;
    }
}
