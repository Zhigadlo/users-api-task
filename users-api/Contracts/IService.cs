namespace Contracts
{
    public interface IService<T> where T : class
    {
        Task<T?> CreateAsync(T entity);
        Task<T?> UpdateAsync(T entity);
        Task<T?> GetAsync(int id);
        IEnumerable<T> GetAll();
        Task<T?> DeleteAsync(int id);
    }
}
