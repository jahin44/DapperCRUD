using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data
{
    public abstract class Repository<TEntity, TKey> : IRepository<TEntity, TKey>
            where TEntity : class, IEntity<TKey>
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public virtual void Add(TEntity entity)
        {
             _dbSet.AddAsync(entity);
        }

        public virtual IList<TEntity> GetAll()
        {
            return _dbSet.ToList();
        }

        public virtual TEntity GetById(TKey Id)
        {
            return _dbSet.Find(Id);
        }

        public void Remove(TEntity entityToDelete)
        {
            if (_dbContext.Entry(entityToDelete).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToDelete);
            }
            _dbSet.Remove(entityToDelete);
        }
        public virtual void Edit(TEntity entityToUpdate)
        {
            if (_dbContext.Entry(entityToUpdate).State == EntityState.Detached)
            {
                _dbSet.Attach(entityToUpdate);
            }
            _dbContext.Entry(entityToUpdate).State = EntityState.Modified;
        }
    }
}
