namespace GerenciamentoRestaurante.Domain.Entities;

public abstract class Entity<TId, TEntity>
    where TId : struct
    where TEntity : Entity<TId, TEntity>
{
    public TId Id { get; set; }
    
    protected Entity()
    {
        Id = default;
    }
}
