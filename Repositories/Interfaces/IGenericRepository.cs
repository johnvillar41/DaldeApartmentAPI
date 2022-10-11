namespace DaldeApartmentAPI.Repositories.Interfaces
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetAsync(string id);
        Task<bool> AddAsync(T entity);
        Task<bool> DeleteAsync(T entity);
        Task<bool> UpdateAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetPaginatedAsync(int position);
    }
}
