namespace AVStore.Domain.Models
{
    public interface IEntity<T>
    {
        T Id { get; set; }
    }

    public interface IEntity
    {
        int Id { get; set; }
    }
}