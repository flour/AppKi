namespace AppKi.Domain;

public abstract class BaseEntity
{
    public DateTime Created { get; set; } = DateTime.UtcNow;
    public DateTime Updated { get; set; } = DateTime.UtcNow;
}

public abstract class BaseEntity<T> : BaseEntity
{
    public T Id { get; set; }
}