using Dapper;
using DapperCRUD.Data.Entityes;
using DapperCRUD.Data.Repositories;
using DapperCRUD.Data.UnitOfWorks;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Transactions;

namespace DapperCRUD.Api.Service
{
    public class ProductService : IProductService
    {
        private readonly UnitOfWork _unitOfWork;
        private readonly ProductRepository _productRepository;
        private readonly IDbConnection _connection;
        public ProductService(UnitOfWork unitOfWork, ProductRepository productRepository, string connectionString)
        {
            _unitOfWork = unitOfWork;
            _productRepository = productRepository;
            _connection = new SqlConnection(connectionString);
        }

        public void Add(Product product)
        {
            if (product == null)
            {
                throw new InvalidOperationException("Not enough data");
            }

            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
                using (var transaction = _connection.BeginTransaction())
                {

                    try
                    {
                        _productRepository.Add(product,
                           "INSERT INTO Product(ProductName, Quantity, Price,Available,LocalTime) VALUES(@ProductName, @Quantity, @Price, @Available, @LocalTime); SELECT SCOPE_IDENTITY()",
                           transaction, _connection);

                        _unitOfWork.Commit(transaction);
                    }
                    catch (Exception)
                    {

                    }
                }
            }

        }

        public void Delete(int ID)
        {

            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
                using (var transaction = _connection.BeginTransaction())
                {

                    try
                    {
                        _productRepository.Delete(ID,
                        "DELETE FROM Product WHERE Id = @Id",
                        transaction, _connection);

                        _unitOfWork.Commit(transaction);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

        public IEnumerable<Product> GetAll()
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();

                try
                {
                    return _productRepository.All(
                    "SELECT * FROM Product ORDER BY ProductName ASC",
                     _connection);
                }
                catch (Exception)
                {

                }

            }
            return null;
        }

        public Product GetById(int Id)
       {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
                using (var transaction = _connection.BeginTransaction())
                {
                    try
                    {
                        return _productRepository.Find(Id,
                        "SELECT * FROM Product WHERE Id = @Id",
                        transaction, _connection);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
            return null;
        }

        public IEnumerable<Product> GetByName(string productName)
        {
            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();

                try
                {
                    return _productRepository.FindByName(productName,
                    "SELECT * FROM Product WHERE ProductName Like CONCAT('%',@ProductName,'%') ORDER BY ProductName ASC",
                    _connection);
                }
                catch (Exception)
                {

                }

            }
            return null;
        }

        public void Update(Product product)
        {
            if (product == null)
            {
                throw new InvalidOperationException("Not enough data");
            }

            if (_connection.State == System.Data.ConnectionState.Closed)
            {
                _connection.Open();
                using (var transaction = _connection.BeginTransaction())
                {

                    try
                    {
                        _productRepository.Update(product,
                        "UPDATE Product SET ProductName = @ProductName, Quantity =@Quantity,Price =@Price,Available =@Available,LocalTime =@LocalTime WHERE Id = @Id",
                        transaction, _connection);
                        _unitOfWork.Commit(transaction);
                    }
                    catch (Exception)
                    {

                    }
                }
            }
        }

 
    }
}
