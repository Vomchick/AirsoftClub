namespace AirsoftClub.Domain.Interfaces
{
    public interface IBaseRepository<T>
    {
        public Task<IEnumerable<T>> GetAllAsync();
        public Task<T> GetAsync(Guid id);
        public Task PostAsync(T entity);
        public Task PutAsync(Guid id, T entity);
        public Task DeleteAsync(Guid id);
    }
}
