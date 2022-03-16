using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace DapperCRUD.Data.Base
{
    public abstract class Repository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        public Repository()
        {

        }
        public virtual void Add(TEntity entity, string sql, IDbTransaction transaction, IDbConnection connection)
        {
            connection.ExecuteScalar<int>(sql, transaction);
        }

        public virtual IEnumerable<TEntity> All(string sql, IDbConnection connection)
        {
            return connection.Query<TEntity>(
                              sql
                              );
        }
        public void Delete(int id, string sql, IDbTransaction transaction, IDbConnection connection)
        {
            connection.Execute(
                            sql,
                            param: new { Id = id },
                            transaction);
        }

        public TEntity Find(int id, string sql, IDbTransaction transaction, IDbConnection connection)
        {
            return connection.Query<TEntity>(
                            sql,
                            param: new { Id = id },
                            transaction
                        ).FirstOrDefault();
        }

        public virtual IEnumerable<TEntity> FindByName(string name, string sql, IDbConnection connection)
        {
            return connection.Query<TEntity>(
                            sql
                        ).ToList();
        }

        public virtual void Update(TEntity entity, string sql, IDbTransaction transaction, IDbConnection connection)
        {
            connection.Execute(
                            sql,
                            transaction
                        );
        }
    }
}
