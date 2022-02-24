using Autofac;
using DapperCRUD.Api.Service;

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
            builder.RegisterType<ProductService>().AsSelf()
                .InstancePerLifetimeScope();
            builder.RegisterType<ProductService>().As<IProductService>()
                .InstancePerLifetimeScope();

            base.Load(builder);
        }

    }
}
