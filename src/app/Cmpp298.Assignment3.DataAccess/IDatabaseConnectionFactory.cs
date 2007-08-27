using System.Data;

namespace Cmpp298.Assignment3.DataAccess {
	public interface IDatabaseConnectionFactory {
		IDbConnection Create( );
	}
}