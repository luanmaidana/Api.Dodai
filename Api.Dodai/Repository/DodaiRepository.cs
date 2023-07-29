using Api.Dodai.Context;
using Api.Dodai.Entities;
using Api.Dodai.Repository.Interface;

namespace Api.Dodai.Repository
{
    public class DodaiRepository : IDodaiRepository
    {
        public DodaiDbContext Context { get; set; }
        private IConfiguration configuration;

        public DodaiRepository(DodaiDbContext _context, IConfiguration _configuration)
        {
            Context = _context;
            configuration = _configuration;
        }

        public IRepository<Produto> Produto => new Repository<Produto>(Context, configuration);

        public void Dispose()
        {
            Context.Dispose();
        }

        public void Rollback()
        {

            if (Context.Database.CurrentTransaction != null) Context.Database.CurrentTransaction.Rollback();
        }

        public void Save()
        {
            var transaction = Context.Database.BeginTransaction();
            Context.SaveChanges();
            transaction.Commit();
        }

        public IRepository<T> Entity<T>() where T : class => new Repository<T>(Context, configuration);

    }
}
