
namespace CleanArchitecture.Application.Parsistence.Contracts;

public  interface IGenericRepository<T> where T : class
{
    Task<T> GetAsync(int Id);
    Task<IReadOnlyList<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);

    Task<bool> ExistAsync(int id);
}
