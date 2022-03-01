using DapperCRUD.Data.Entityes;
using System.Collections.Generic;
using System.Data;

namespace DapperCRUD.Api
{
    public interface IProductService
    {
        DataTable GetAll();
        Product GetById(int id);
        IEnumerable<Product> GetByName(string productName);
        void Add(Product prod);
        void Update(Product product);
        void Delete(int ID);

    }
}
