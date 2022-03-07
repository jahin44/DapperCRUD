using Dapper;
using DapperCRUD.Data.Entityes;
using DapperCRUD.Data.UnitOfWorks;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DapperCRUD.Api.Service
{
    public class ProductService : IProductService
    {
        private readonly UnitOfWork _unitOfWork;

        public ProductService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void Add(Product product)
        {   if (product == null)
            {
                throw new InvalidOperationException("Not enough data");
            }

            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.Commit();
        }

        public DataTable GetAll()
        {
            var entities = _unitOfWork.ProductRepository.All();
            var table = new DataTable();

            table.Columns.Add("Id", typeof(int));
            table.Columns.Add("Product", typeof(string));
            table.Columns.Add("Quantity", typeof(int));
            table.Columns.Add("Price", typeof(int));
            table.Columns.Add("LocalTime", typeof(string));


            foreach (var entity in entities)
            {
                var row = table.NewRow();
                row["Id"] = entity.Id;
                row["Product"] = entity.ProductName.ToString();
                row["Quantity"] = entity.Quantity;
                row["Price"] = entity.Price;
                row["LocalTime"] = entity.LocalTime;
                table.Rows.Add(row);
            }
            return table;
        }

        public Product GetById(int id)
        {
            return _unitOfWork.ProductRepository.Find(id);
        }
        public IEnumerable<Product> GetByName(string productName)
        {
            return _unitOfWork.ProductRepository.FindByName(productName);
        }

        public void Delete(int id)
        {
            _unitOfWork.ProductRepository.Delete(id);
            _unitOfWork.Commit();
        }

        public void Update(Product product)
        {
            _unitOfWork.ProductRepository.Update(product);
            _unitOfWork.Commit();
        }
    }
}
