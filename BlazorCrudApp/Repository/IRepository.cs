using System.Linq.Expressions;

namespace BlazorCrudApp.Repository
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IEnumerable<T> GetAll();

        IEnumerable<T> Find(Expression<Func<T, bool>> expression);

        void Add(T entity);
        void Delete(T Delete);
        void Update(T entity);
        T GetByID(int id);
    }
}
