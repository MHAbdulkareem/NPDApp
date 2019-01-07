using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
/*
 * TEAM MEMBERS
 * AMINU ABDULMALIK (16040781)
 * MUHAMMAD HUSSAINI (17045588)
 */
namespace NPDApp.DataAccess
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly NDPAppContext _dbContext;
        private DbSet<TEntity> _dbSet;

        public GenericRepository(NDPAppContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public virtual IQueryable<TEntity> Get()
        {
            IQueryable<TEntity> query = _dbSet;
            return query;
        }

        public virtual TEntity GetByID(object ID)
        {
            return _dbSet.Find(ID);
        }

        public virtual void Insert(TEntity tEntity)
        {
            _dbSet.Add(tEntity);
        }

        public virtual void Delete(TEntity tEntity)
        {
            _dbSet.Remove(tEntity);
        }

        public virtual IQueryable<TEntity> SearchFor(Expression<Func<TEntity, bool>> predicate)
        {
            return _dbSet.Where(predicate);
        }

        public virtual void Update(TEntity tEntity)
        {
            _dbSet.Attach(tEntity);
            _dbContext.SetModified(tEntity);
        }
    }
}
