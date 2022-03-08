using Dapper;
using DapperCRUD.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data.Repositories
{
    internal class ProductRepository : Repository, IProductRepository
    {
        public ProductRepository(IDbTransaction transaction) : base(transaction)
        {
        }

        public void Add(Product entity)
        {
            entity.Id = Connection.ExecuteScalar<int>(
                "INSERT INTO Product(ProductName, Quantity, Price,Available,LocalTime) VALUES(@ProductName, @Quantity, @Price, @Available, @LocalTime); SELECT SCOPE_IDENTITY()",
                param: new { ProductName = entity.ProductName,
                             Quantity = entity.Quantity,
                             Price = entity.Price,
                             Available=entity.Available,
                             LocalTime = entity.LocalTime},
                transaction: Transaction
            );
        }

        public IEnumerable<Product> All()
        {
            return Connection.Query<Product>(
                            "SELECT * FROM Product ORDER BY ProductName ASC",
                            transaction: Transaction
                        ).ToList();
        }

        public void Delete(int id)
        {
            Connection.Execute(
                            "DELETE FROM Product WHERE Id = @Id",
                            param: new { Id = id },
                            transaction: Transaction
                        );
        }

        public void Delete(Product entity)
        {
            Delete(entity.Id);
        }

        public Product Find(int id)
        {
            return Connection.Query<Product>(
                "SELECT * FROM Product WHERE Id = @Id",
                param: new { Id = id },
                transaction: Transaction
            ).FirstOrDefault();
        }

        public IEnumerable<Product> FindByName(string name)
        {
            return Connection.Query<Product>(
                            "SELECT * FROM Product WHERE ProductName = @ProductName",
                            param: new { ProductName = name },
                            transaction: Transaction
                        ).ToList();
        }

        public void Update(Product entity)
        {
            Connection.Execute(
                            "UPDATE Product SET ProductName = @ProductName, Quantity =@Quantity,Price =@Price,Available =@Available,LocalTime =@LocalTime WHERE Id = @Id",
                            param: new { ProductName = entity.ProductName,
                                         Quantity = entity.Quantity, 
                                         Price= entity.Price,
                                         Available= entity.Available,
                                         LocalTime = entity.LocalTime,
                                         Id = entity.Id },
                            transaction: Transaction
                        );
        }
    }
}
