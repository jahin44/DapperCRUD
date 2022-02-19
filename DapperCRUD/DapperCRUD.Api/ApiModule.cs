using Autofac;
using DapperCRUD.Api.Repository;

namespace DapperCRUD.Api
{
    public class ApiModule : Module
    {
        private readonly string _connectionString;
        private readonly string _migrationAssemblyName;

        public ApiModule(string connectionString, string migrationAssemblyName)
        {
            _connectionString = connectionString;
            _migrationAssemblyName = migrationAssemblyName;
        }
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductRepository>().AsSelf()
                .WithParameter("connectionString", _connectionString)
                .InstancePerLifetimeScope();

            builder.RegisterType<ProductRepository>().As<IRepository>()
                .WithParameter("connectionString", _connectionString)
                .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
