namespace Contracts
{
    public interface IService<T> where T : class
    {
        T? Create(T entity);
        T? Delete(int id);
        IQueryable<T>? GetAll(bool trackChanges);
        T? Get(int id, bool trackChanges);
        T? Update(T entity);
    }
}
