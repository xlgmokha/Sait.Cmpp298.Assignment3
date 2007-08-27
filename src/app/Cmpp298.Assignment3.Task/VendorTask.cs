using System.Collections.Generic;
using System.Data;
using Cmpp298.Assignment3.DataAccess;
using Cmpp298.Assignment3.Dto;

namespace Cmpp298.Assignment3.Task {
	public class VendorTask : IVendorTask {
		private IDatabaseGateway _gateway;

		public VendorTask( ) : this( new DatabaseGateway( ) ) {}

		public VendorTask( IDatabaseGateway gateway ) {
			_gateway = gateway;
		}

		public IEnumerable< IDropDownListItem > GetAllVendorNames( ) {
			SelectQueryBuilder builder = new SelectQueryBuilder( Tables.Vendors.TableName );
			builder.AddColumn( Tables.Vendors.VendorID );
			builder.AddColumn( Tables.Vendors.Name );
			return CreateItemsFrom( _gateway.GetTableFrom( builder ) );
		}

		public DisplayVendorNameDto FindVendorNameBy( string vendorId ) {
			SelectQueryBuilder builder = new SelectQueryBuilder( Tables.Vendors.TableName );
			builder.AddColumn( Tables.Vendors.VendorID );
			builder.AddColumn( Tables.Vendors.Name );
			builder.Where( Tables.Vendors.VendorID, vendorId );
			return CreateDtoFrom( _gateway.GetTableFrom( builder ) );
		}

		private static DisplayVendorNameDto CreateDtoFrom( DataTable resultSet ) {
			return new DisplayVendorNameDto( resultSet.Rows[ 0 ][ Tables.Vendors.VendorID.ColumnName ].ToString( ),
			                                 resultSet.Rows[ 0 ][ Tables.Vendors.Name.ColumnName ].ToString( ) );
		}

		private static IEnumerable< IDropDownListItem > CreateItemsFrom( DataTable table ) {
			foreach ( DataRow row in table.Rows ) {
				yield return
					new DropDownListItem( row[ Tables.Vendors.Name.ColumnName ].ToString( ),
					                      row[ Tables.Vendors.VendorID.ColumnName ].ToString( ) );
			}
		}
	}
}