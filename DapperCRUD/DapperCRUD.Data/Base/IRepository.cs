using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DapperCRUD.Data.Base
{
    public interface IRepository<TEntity>
        where TEntity : class
    {
        void Add(TEntity entity, string sql, IDbTransaction transaction, IDbConnection connection);
        IEnumerable<TEntity> All(string sql, IDbConnection connection);
        void Delete(int id, string sql, IDbTransaction transaction, IDbConnection connection);
        TEntity Find(int id, string sql, IDbTransaction transaction, IDbConnection connection);
        IEnumerable<TEntity> FindByName(string name, string sql, IDbConnection connection);
        void Update(TEntity entity, string sql, IDbTransaction transaction, IDbConnection connection);

    }
}
