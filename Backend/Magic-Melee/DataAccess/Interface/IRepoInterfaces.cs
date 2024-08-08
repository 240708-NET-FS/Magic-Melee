using MagicMelee.Models;

namespace MagicMelee.Data;

public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(int id);
    Task<IEnumerable<T>> GetAllAsync();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(int id);
}

public interface ILoginRepo : IRepository<Login>
{
    //define methods specific to login if needed
}

public interface IUserRepo : IRepository<User>
{
    // define methods specific to user if needed
}

// Add additional interfaces if needed