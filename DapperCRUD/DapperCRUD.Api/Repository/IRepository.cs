using System.Collections.Generic;

namespace DapperCRUD.Api.Repository
{
    public interface IRepository
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product prod);
        void Update(Product prod);
        void Delete(int iD);
    }
}
