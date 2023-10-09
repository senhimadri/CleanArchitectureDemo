using CleanArchitecture.Application.Parsistence.Contracts;

namespace CleanArchitecture.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : class
{
    public Task<T> AddAsync(T entity)
    {
        throw new NotImplementedException();
    }

    public Task<T> DeleteAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> ExistAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<T>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<T> GetAsync(int Id)
    {
        throw new NotImplementedException();
    }

    public Task<T> UpdateAsync(T entity)
    {
        throw new NotImplementedException();
    }
}
