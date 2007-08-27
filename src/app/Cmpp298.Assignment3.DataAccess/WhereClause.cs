namespace Cmpp298.Assignment3.DataAccess {
	public class WhereClause {
		private readonly DatabaseColumn _column;
		private readonly string _value;

		public WhereClause( DatabaseColumn column, string value ) {
			_column = column;
			_value = value;
		}

		public DatabaseColumn Column {
			get { return _column; }
		}

		public string Value {
			get { return _value; }
		}

		public override string ToString( ) {
			return string.Format( " WHERE [{0}].[{1}] = {2};", _column.TableName, _column.ColumnName, _value );
		}
	}
}