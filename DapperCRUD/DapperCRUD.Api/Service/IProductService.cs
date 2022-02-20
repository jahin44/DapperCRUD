using System.Collections.Generic;

namespace DapperCRUD.Api
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product GetById(int id);
        void Add(Product prod);
        void Update(Product prod);
        void Delete(int ID);

    }
}
