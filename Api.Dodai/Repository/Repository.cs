using Api.Dodai.Repository.Interface;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Api.Dodai.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbContext Contexto;
        private readonly string ConnectionString;

        public Repository(DbContext entities, IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DodaiDB") ?? string.Empty;
            if (Contexto == null)
                Contexto = entities;
        }

        protected virtual DbSet<T> DbSet
        {
            get { return Contexto.Set<T>(); }
        }

        public void Add(T model)
        {
            DbSet.Add(model);
        }

        public bool Exists(Expression<Func<T, bool>> expression)
        {
            T result = (T)DbSet.Where(expression).FirstOrDefault();
            return result != null;
        }

        public IQueryable<T> FindAll()
        {
            return DbSet.AsQueryable();
        }

        public IQueryable<T> FindBy(Expression<Func<T, bool>> expression)
        {
            return DbSet.Where(expression).AsQueryable<T>();
        }

        public void Remove(T model)
        {
            DbSet.Remove(model);
        }

        public void Update(T model)
        {
            if (Contexto.Entry(model).State == EntityState.Detached)
                DbSet.Attach(model);

            Contexto.Entry(model).State = EntityState.Modified;
            Contexto.ChangeTracker.DetectChanges();
        }

        public IEnumerable<D> DapperQuery<D>(string query)
        {
            return new SqlConnection(ConnectionString).Query<D>(query);
        }
    }
}
