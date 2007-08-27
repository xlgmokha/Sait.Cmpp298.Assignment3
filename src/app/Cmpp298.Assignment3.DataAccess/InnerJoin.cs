namespace Cmpp298.Assignment3.DataAccess {
	public class InnerJoin {
		public InnerJoin( string leftTableName, string leftColumnName, string rightTableName, string rightColumnName )
			: this( new DatabaseColumn( leftTableName, leftColumnName ), new DatabaseColumn( rightTableName, rightColumnName ) ) {}

		public InnerJoin( DatabaseColumn leftColumn, DatabaseColumn rightColumn ) {
			_leftColumn = leftColumn;
			_rightColumn = rightColumn;
		}

		public override string ToString( ) {
			return
				string.Format( "INNER JOIN [{0}] ON [{0}].[{1}] = [{2}].[{3}]",
				               _leftColumn.TableName,
				               _leftColumn.ColumnName,
				               _rightColumn.TableName,
				               _rightColumn.ColumnName );
		}

		private readonly DatabaseColumn _leftColumn;
		private readonly DatabaseColumn _rightColumn;
	}
}