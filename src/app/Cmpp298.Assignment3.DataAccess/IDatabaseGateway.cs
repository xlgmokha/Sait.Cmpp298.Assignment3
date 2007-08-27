using System.Data;

namespace Cmpp298.Assignment3.DataAccess {
	public interface IDatabaseGateway {
		DataTable GetTableFrom( SelectQueryBuilder builder );

		int InsertRowUsing( InsertQueryBuilder builder );

		void UpdateRowUsing( UpdateQueryBuilder builder );

		void Execute( string query );
	}
}