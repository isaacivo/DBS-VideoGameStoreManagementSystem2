using System.Collections.Generic;

namespace VideoGameRentalManagementSystem.DAL.IRepositories
{
    // Demonstrates Abstraction via Interface
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void Delete(int id);
        List<T> GetAll();
        T? GetById(int id);
    }
}
