using DapperCRUD.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IProductRepository ProductRepository { get; }

        void Commit();
    }
}
