using System.Collections.Generic;
using System.Data;
using Cmpp298.Assignment3.DataAccess;
using Cmpp298.Assignment3.Dto;

namespace Cmpp298.Assignment3.Task {
	public class TermTask : ITermTask {
		private IDatabaseGateway _gateway;

		public TermTask( ) : this( new DatabaseGateway( ) ) {}

		public TermTask( IDatabaseGateway gateway ) {
			_gateway = gateway;
		}

		public IEnumerable< IDropDownListItem > GetAll( ) {
			SelectQueryBuilder builder = new SelectQueryBuilder( Tables.Terms.TableName );
			builder.AddColumn( Tables.Terms.TermsID );
			builder.AddColumn( Tables.Terms.Description );
			return CreateFrom( _gateway.GetTableFrom( builder ) );
		}

		private static IEnumerable< IDropDownListItem > CreateFrom( DataTable table ) {
			foreach ( DataRow row in table.Rows ) {
				yield return
					new DropDownListItem( row[ Tables.Terms.Description.ColumnName ].ToString( ),
					                      row[ Tables.Terms.TermsID.ColumnName ].ToString( ) );
			}
		}
	}
}