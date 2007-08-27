using System;
using System.Collections.Generic;
using System.Data;

namespace Cmpp298.Assignment3.DataAccess {
	public class DatabaseGateway : IDatabaseGateway {
		private IDatabaseConnectionFactory _connectionFactory;

		public DatabaseGateway( ) : this( new DatabaseConnectionFactory( ) ) {}

		public DatabaseGateway( IDatabaseConnectionFactory connectionFactory ) {
			_connectionFactory = connectionFactory;
		}

		public int InsertRowUsing( InsertQueryBuilder builder ) {
			return ExecuteBuilderQuery( builder.Parameters, builder.ToString( ) );
		}

		public void UpdateRowUsing( UpdateQueryBuilder builder ) {
			ExecuteBuilderQuery( builder.Parameters, builder.ToString( ) );
		}

		public void Execute( string query ) {
			using ( IDbConnection connection = _connectionFactory.Create( ) ) {
				IDbCommand command = connection.CreateCommand( );
				connection.Open( );
				command.CommandText = query;
				command.ExecuteNonQuery( );
			}
		}

		public DataTable GetTableFrom( SelectQueryBuilder builder ) {
			return GetTableFrom( builder.ToString( ) );
		}

		private DataTable GetTableFrom( string sqlQuery ) {
			using ( IDbConnection connection = _connectionFactory.Create( ) ) {
				IDbCommand command = connection.CreateCommand( );
				command.CommandText = sqlQuery;
				connection.Open( );
				IDataReader reader = command.ExecuteReader( );
				DataTable table = new DataTable( );
				table.Load( reader );
				return table;
			}
		}

		private int ExecuteBuilderQuery( ICollection< CommandParameter > parameters, string commandText ) {
			object scalar;
			using ( IDbConnection connection = _connectionFactory.Create( ) ) {
				IDbCommand command = connection.CreateCommand( );

				foreach ( CommandParameter parameter in parameters ) {
					IDataParameter commandParameter = command.CreateParameter( );
					commandParameter.ParameterName = "@" + parameter.ColumnName;
					commandParameter.Value = parameter.Value;
					command.Parameters.Add( commandParameter );
				}

				command.CommandText = commandText;
				connection.Open( );
				scalar = command.ExecuteScalar( );
			}
			return DBNull.Value != scalar ? Convert.ToInt32( scalar ) : -1;
		}
	}
}