namespace Cmpp298.Assignment3.DataAccess {
	public class CommandParameter {
		private readonly string _columnName;
		private readonly object _value;

		public CommandParameter( string columnName, object value ) {
			_columnName = columnName;
			_value = value;
		}

		public string ColumnName {
			get { return _columnName; }
		}

		public object Value {
			get { return _value; }
		}
	}
}