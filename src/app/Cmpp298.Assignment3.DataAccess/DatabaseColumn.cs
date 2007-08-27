namespace Cmpp298.Assignment3.DataAccess {
	public class DatabaseColumn {
		private readonly string _tableName;
		private readonly string _columnName;

		internal DatabaseColumn( string tableName, string columnName ) {
			_tableName = tableName;
			_columnName = columnName;
		}

		public string TableName {
			get { return _tableName; }
		}

		public string ColumnName {
			get { return _columnName; }
		}

		public override string ToString( ) {
			return string.Format( "[{0}].[{1}]", _tableName, _columnName );
		}
	}
}