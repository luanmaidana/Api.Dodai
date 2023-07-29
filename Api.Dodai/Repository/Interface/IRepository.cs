using System.Linq.Expressions;

namespace Api.Dodai.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        void Add(T model);
        void Update(T model);
        void Remove(T model);

        IQueryable<T> FindAll();

        IEnumerable<D> DapperQuery<D>(string query);

        IQueryable<T> FindBy(Expression<Func<T, bool>> expression);
        bool Exists(Expression<Func<T, bool>> expression);
    }
}
