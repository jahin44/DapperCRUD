using Dapper;
using DapperCRUD.Data.Base;
using DapperCRUD.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository()
        {
        }
        public override void Add(Product entity, string sql, IDbTransaction transaction, IDbConnection connection)
        {
            connection.ExecuteScalar<int>(sql,
                param: new
                {
                    ProductName = entity.ProductName,
                    Quantity = entity.Quantity,
                    Price = entity.Price,
                    Available = entity.Available,
                    LocalTime = entity.LocalTime
                }, transaction);
        }
        public override void Update(Product entity, string sql, IDbTransaction transaction, IDbConnection connection)
        {
            connection.ExecuteScalar<int>(sql,
                param: new
                {
                    ProductName = entity.ProductName,
                    Quantity = entity.Quantity,
                    Price = entity.Price,
                    Available = entity.Available,
                    LocalTime = entity.LocalTime,
                    Id = entity.Id
                }, transaction);
        }
        public override IEnumerable<Product> FindByName(string ProductName, string sql, IDbConnection connection)
        {
            return connection.Query<Product>(
                            sql,
                            param: new { ProductName = ProductName }
                        ).ToList();
        }
    }
}
