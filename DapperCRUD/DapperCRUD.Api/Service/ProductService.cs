using Dapper;
using DapperCRUD.Data.Entityes;
using DapperCRUD.Data.UnitOfWorks;
using Microsoft.Data.SqlClient;
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
        {
            _unitOfWork.ProductRepository.Add(product);
            _unitOfWork.Commit();       
        }

        public IEnumerable<Product> GetAll()
        {            
            return _unitOfWork.ProductRepository.All();
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
