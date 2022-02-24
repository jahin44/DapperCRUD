using DapperCRUD.Data.Entityes;
using System.Collections.Generic;

namespace DapperCRUD.Api
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        IEnumerable<Product> GetByName(string productName);
        void Add(Product prod);
        void Update(Product product);
        void Delete(int ID);

    }
}
