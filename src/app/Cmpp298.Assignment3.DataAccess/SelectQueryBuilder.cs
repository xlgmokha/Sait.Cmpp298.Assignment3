using System.Collections.Generic;
using System.Text;

namespace Cmpp298.Assignment3.DataAccess {
	public class SelectQueryBuilder {
		private readonly string _tableName;
		private IList< DatabaseColumn > _selectColumns;
		private IList< InnerJoin > _innerJoins;
		private WhereClause _whereClause;

		public SelectQueryBuilder( string tableName ) {
			_tableName = tableName;
			_innerJoins = new List< InnerJoin >( );
			_selectColumns = new List< DatabaseColumn >( );
		}

		public void AddColumn( DatabaseColumn column ) {
			_selectColumns.Add( column );
		}

		public void InnerJoin( DatabaseColumn leftColumn, DatabaseColumn rightColumn ) {
			_innerJoins.Add( new InnerJoin( leftColumn, rightColumn ) );
		}

		public void Where( DatabaseColumn column, string value ) {
			_whereClause = new WhereClause( column, value );
		}

		public override string ToString( ) {
			return string.Format( "SELECT {0} FROM {1} {2} {3};", GetColumnNames( ), _tableName, GetInnerJoins( ), _whereClause );
		}

		private string GetInnerJoins( ) {
			StringBuilder builder = new StringBuilder( );
			foreach ( InnerJoin innerJoin in _innerJoins ) {
				builder.Append( innerJoin.ToString( ) );
			}
			return builder.ToString( );
		}

		private string GetColumnNames( ) {
			StringBuilder builder = new StringBuilder( );
			foreach ( DatabaseColumn selectColumn in _selectColumns ) {
				builder.AppendFormat( "{0},", selectColumn );
			}
			builder.Remove( builder.Length - 1, 1 );
			return builder.ToString( );
		}
	}
}