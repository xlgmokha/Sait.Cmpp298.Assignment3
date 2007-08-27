using System.Configuration;
using System.Data;
using System.Data.Common;

namespace Cmpp298.Assignment3.DataAccess {
	public class DatabaseConnectionFactory : IDatabaseConnectionFactory {
		private ConnectionStringSettings _settings;

		public DatabaseConnectionFactory( ) : this( ConfigurationManager.ConnectionStrings[ "PayablesConnection" ] ) {}

		public DatabaseConnectionFactory( ConnectionStringSettings connectionStringSettings ) {
			_settings = connectionStringSettings;
		}

		public IDbConnection Create( ) {
			IDbConnection connection = DbProviderFactories.GetFactory( _settings.ProviderName ).CreateConnection( );
			connection.ConnectionString = _settings.ConnectionString;
			return connection;
		}
	}
}