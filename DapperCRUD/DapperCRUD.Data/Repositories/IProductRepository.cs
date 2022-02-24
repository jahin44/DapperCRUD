using DapperCRUD.Data.Entityes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data.Repositories
{
    public interface IProductRepository
    {
        void Add(Product entity);
        IEnumerable<Product> All();
        void Delete(int id);
        void Delete(Product entity);
        Product Find(int id);
        IEnumerable<Product> FindByName(string name);
        void Update(Product entity);
    }
}
