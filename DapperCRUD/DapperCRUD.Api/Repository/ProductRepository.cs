using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DapperCRUD.Api.Repository
{
    public class ProductRepository : IRepository
    {
        private string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        //Perist Security Info=False;Initial Catalog = Product;
        public IDbConnection Connection
        {
            get
            {
                return new SqlConnection(_connectionString);
            }
        }

        public void Add(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"INSERT INTO Product (ID,ProductName,Quantity,Price) VALUES(@ID,@ProductName,@Quantity,@Price)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, prod);
            }
        }

        public IEnumerable<Product> GetAll()
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Product";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery);
            }
        }

        public Product GetById(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"SELECT * FROM Product WHERE ID=@Id";
                dbConnection.Open();
                return dbConnection.Query<Product>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }

        public void Delete(int id)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"DELETE FROM Product WHERE ID=@Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(Product prod)
        {
            using (IDbConnection dbConnection = Connection)
            {
                string sQuery = @"UPDATE Product SET ProductName=@ProductName,Quantity=@Quantity,Price=@Price WHERE ID=@Id";
                dbConnection.Open();
                dbConnection.Query(sQuery, prod);
            }
        }
    }
}
