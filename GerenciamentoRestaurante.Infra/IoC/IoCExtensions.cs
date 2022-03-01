using GerenciamentoRestaurante.Infra.Data;
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
}
