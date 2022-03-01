using GerenciamentoRestaurante.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoRestaurante.Infra.Data;

public class Context : DbContext
{
    public Context(DbContextOptions<Context> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PessoaMapping());
        modelBuilder.ApplyConfiguration(new UsuarioMapping());
        modelBuilder.ApplyConfiguration(new ItemCardapioMapping());
        modelBuilder.ApplyConfiguration(new PedidoMapping());
        modelBuilder.ApplyConfiguration(new PedidoItemMapping());
    }
}
