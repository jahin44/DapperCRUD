using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data.Repositories
{
    internal class Repository
    {
        protected IDbTransaction Transaction { get; private set; }
        protected IDbConnection Connection { get { return Transaction.Connection; } }

        public Repository(IDbTransaction transaction)
        {
            Transaction = transaction;
        }
    }
}
