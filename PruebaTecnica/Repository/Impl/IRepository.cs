using System.Linq.Expressions;

namespace PruebaTecnica.Repository.Impl
{
    public interface IRepository<T> where T : class
    {
        T Get(int id);

        void Add(T entity);

        void AddRange(List<T> Entities);
    }
}
