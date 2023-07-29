using Api.Dodai.Entities;

namespace Api.Dodai.Repository.Interface
{
    public interface IDodaiRepository : IDisposable
    {
        void Save();
        void Rollback();
        IRepository<Produto> Produto { get; }
        IRepository<T> Entity<T>() where T : class;


    }
}
