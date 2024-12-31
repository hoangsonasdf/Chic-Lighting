namespace projectchicandlighting.Repositories
{
    public interface IRepository<T>
    {
        Task<List<T>> GetAll();
        Task<T> GetById(string id);
        Task Add(T t);
        Task Update(string id, T t);
        Task Delete(string id);
    }
}
