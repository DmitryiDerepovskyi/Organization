using System.Configuration;
using System.Data;
using System.Data.Common;
using Organization.Core;

namespace Organization.DAL
{
    public abstract class AdoNetDataAccessLayer<T> : BaseEntity
    {
        protected readonly IDbConnection _connection;
        private readonly DbProviderFactory _factory;

        protected AdoNetDataAccessLayer()
        {
            var conStr = ConfigurationManager.ConnectionStrings["OrganizationDbConnectionString"];
            if (conStr == null)
                throw new ConfigurationErrorsException(
                    string.Format("Failed to find connection string named OrganizationDbConnectionString in app/web.config."));
            
            _factory = DbProviderFactories.GetFactory(conStr.ProviderName);
            _connection = _factory.CreateConnection();
            _connection.ConnectionString = conStr.ConnectionString;
        }
        protected abstract void Map(IDataRecord record, T entity);
    }
}
