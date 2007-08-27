using System.Collections.Generic;
using System.Text;

namespace Cmpp298.Assignment3.DataAccess {
	public class InsertQueryBuilder {
		private readonly string _tableName;
		private IList< CommandParameter > _parameters;

		public InsertQueryBuilder( string tableName ) {
			_tableName = tableName;
			_parameters = new List< CommandParameter >( );
		}

		public IList< CommandParameter > Parameters {
			get { return _parameters; }
		}

		public void Add( DatabaseColumn column, string value ) {
			_parameters.Add( new CommandParameter( column.ColumnName, value ) );
		}

		public override string ToString( ) {
			StringBuilder builder = new StringBuilder( );
			builder.AppendFormat( "INSERT INTO {0} ({1}) VALUES ({2});SELECT @@IDENTITY;", _tableName,
			                      GetParameterNames( string.Empty ),
			                      GetParameterNames( "@" ) );
			return builder.ToString( );
		}

		private string GetParameterNames( string prefix ) {
			StringBuilder builder = new StringBuilder( );
			foreach ( CommandParameter parameter in _parameters ) {
				builder.AppendFormat( "{0}{1},", prefix, parameter.ColumnName );
			}
			builder.Remove( builder.Length - 1, 1 );
			return builder.ToString( );
		}
	}
}