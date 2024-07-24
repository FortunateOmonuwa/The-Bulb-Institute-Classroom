namespace OrganizationMgtSys.DataAccess.Interfaces
{
    public interface IBaseService<T>
    {
        Task<T> CreateAsync(T entity);
        Task<T> GetAsync(Guid id);
        Task<List<T>> GetAll();
        Task<string> DeleteAsync(Guid id);
        Task<T> UpdateAsync(T entity, Guid id);
    }
}
