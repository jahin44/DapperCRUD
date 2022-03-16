using Autofac;
using DapperCRUD.Data.Base;
using DapperCRUD.Data.Repositories;
using DapperCRUD.Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DapperCRUD.Data
{
    public class DataModule: Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public DataModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>()
                .WithParameter("connectionString", _connectionString)
                .InstancePerLifetimeScope();
            builder.RegisterType<UnitOfWork>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().As<IProductRepository>()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductRepository>().AsSelf()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
