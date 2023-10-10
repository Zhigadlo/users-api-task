namespace Contracts.Service
{
    public interface IService<Tdto, TdtoForCreation, TdtoForUpdate> where Tdto : class
                                                                    where TdtoForCreation : class
                                                                    where TdtoForUpdate : class
    {
        Tdto? Create(TdtoForCreation entity);
        Tdto? Delete(int id);
        IEnumerable<Tdto>? GetAll(bool trackChanges);
        Tdto? Get(int id, bool trackChanges);
        Tdto? Update(TdtoForUpdate entity);
    }
}
