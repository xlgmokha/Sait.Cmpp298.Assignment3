using System.Collections.Generic;
using System.Text;

namespace Cmpp298.Assignment3.DataAccess {
	public class UpdateQueryBuilder {
		private IList< CommandParameter > _parameters;
		private WhereClause _where;

		public UpdateQueryBuilder( DatabaseColumn whereColumn, string whereValue )
			: this( new List< CommandParameter >( ), new WhereClause( whereColumn, whereValue ) ) {}

		public UpdateQueryBuilder( IList< CommandParameter > parameters, WhereClause where ) {
			_parameters = parameters;
			_where = where;
		}

		public IList< CommandParameter > Parameters {
			get { return _parameters; }
		}

		public void Add( DatabaseColumn column, string value ) {
			_parameters.Add( new CommandParameter( column.ColumnName, value ) );
		}

		public override string ToString( ) {
			StringBuilder builder = new StringBuilder( );
			builder.AppendFormat( "UPDATE [{0}] SET {1};", _where.Column.TableName, GetParameterNames( ) );

			return builder.ToString( );
		}

		private string GetParameterNames( ) {
			StringBuilder builder = new StringBuilder( );
			foreach ( CommandParameter parameter in _parameters ) {
				builder.AppendFormat( "[{0}].[{1}] = @{1},", _where.Column.TableName, parameter.ColumnName );
			}
			builder.Remove( builder.Length - 1, 1 );
			builder.Append( _where );
			return builder.ToString( );
		}
	}
}