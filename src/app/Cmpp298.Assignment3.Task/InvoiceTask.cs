using System.Collections.Generic;
using System.Data;
using System.Text;
using Cmpp298.Assignment3.DataAccess;
using Cmpp298.Assignment3.Dto;

namespace Cmpp298.Assignment3.Task {
	public class InvoiceTask : IInvoiceTask {
		public InvoiceTask( ) : this( new DatabaseGateway( ) ) {}

		public InvoiceTask( IDatabaseGateway gateway ) {
			_gateway = gateway;
		}

		public int SaveNewInvoice( SaveInvoiceDto saveInvoiceDto ) {
			InsertQueryBuilder builder = new InsertQueryBuilder( Tables.Invoices.TableName );
			builder.Add( Tables.Invoices.VendorID, saveInvoiceDto.VendorId );
			builder.Add( Tables.Invoices.InvoiceNumber, saveInvoiceDto.InvoiceNumber );
			builder.Add( Tables.Invoices.InvoiceDate, saveInvoiceDto.InvoiceDate );
			builder.Add( Tables.Invoices.InvoiceTotal, saveInvoiceDto.InvoiceTotal );
			builder.Add( Tables.Invoices.PaymentTotal, saveInvoiceDto.PaymentTotal );
			builder.Add( Tables.Invoices.CreditTotal, saveInvoiceDto.CreditTotal );
			builder.Add( Tables.Invoices.TermsID, saveInvoiceDto.TermsId );
			builder.Add( Tables.Invoices.DueDate, saveInvoiceDto.DueDate );
			builder.Add( Tables.Invoices.PaymentDate, saveInvoiceDto.PaymentDate );

			return _gateway.InsertRowUsing( builder );
		}

		public IEnumerable< DisplayInvoiceDto > GetAllInvoices( string forVendorId ) {
			SelectQueryBuilder builder = new SelectQueryBuilder( Tables.Invoices.TableName );
			builder.AddColumn( Tables.Invoices.InvoiceID );
			builder.AddColumn( Tables.Invoices.InvoiceNumber );
			builder.AddColumn( Tables.Invoices.InvoiceDate );
			builder.AddColumn( Tables.Invoices.InvoiceTotal );
			builder.AddColumn( Tables.Invoices.PaymentTotal );
			builder.AddColumn( Tables.Invoices.CreditTotal );
			builder.AddColumn( Tables.Invoices.DueDate );
			builder.AddColumn( Tables.Invoices.PaymentDate );
			builder.AddColumn( Tables.Terms.Description );
			builder.AddColumn( Tables.Vendors.Name );
			builder.InnerJoin( Tables.Terms.TermsID, Tables.Invoices.TermsID );
			builder.InnerJoin( Tables.Vendors.VendorID, Tables.Invoices.VendorID );
			builder.Where( Tables.Invoices.VendorID, forVendorId );

			IList< DisplayInvoiceDto > dtos = new List< DisplayInvoiceDto >( );
			foreach ( DataRow row in _gateway.GetTableFrom( builder ).Rows ) {
				dtos.Add( CreateFrom( row ) );
			}
			return dtos;
		}

		public DisplayInvoiceDto GetInvoiceBy( string invoiceId ) {
			SelectQueryBuilder builder = new SelectQueryBuilder( Tables.Invoices.TableName );
			builder.AddColumn( Tables.Invoices.InvoiceID );
			builder.AddColumn( Tables.Invoices.InvoiceNumber );
			builder.AddColumn( Tables.Invoices.InvoiceDate );
			builder.AddColumn( Tables.Invoices.InvoiceTotal );
			builder.AddColumn( Tables.Invoices.PaymentTotal );
			builder.AddColumn( Tables.Invoices.CreditTotal );
			builder.AddColumn( Tables.Invoices.DueDate );
			builder.AddColumn( Tables.Invoices.PaymentDate );
			builder.AddColumn( Tables.Terms.Description );
			builder.AddColumn( Tables.Vendors.Name );
			builder.InnerJoin( Tables.Terms.TermsID, Tables.Invoices.TermsID );
			builder.InnerJoin( Tables.Vendors.VendorID, Tables.Invoices.VendorID );
			builder.Where( Tables.Invoices.InvoiceID, invoiceId );
			DataTable table = _gateway.GetTableFrom( builder );
			return table.Rows.Count == 1 ? CreateFrom( table.Rows[ 0 ] ) : null;
		}

		public void DeleteInvoice( string invoiceId ) {
			StringBuilder builder = new StringBuilder( );

			builder.AppendFormat( "DELETE FROM [{0}] WHERE [{0}].[{1}] = {2}",
			                      Tables.Invoices.TableName,
			                      Tables.Invoices.InvoiceID.ColumnName,
			                      invoiceId );

			_gateway.Execute( builder.ToString( ) );
		}

		public void UpdateInvoice( UpdateInvoiceDto dto ) {
			UpdateQueryBuilder builder = new UpdateQueryBuilder( Tables.Invoices.InvoiceID, dto.InvoiceId );
			builder.Add( Tables.Invoices.CreditTotal, dto.CreditTotal );
			builder.Add( Tables.Invoices.DueDate, dto.DueDate );
			builder.Add( Tables.Invoices.InvoiceDate, dto.InvoiceDate );
			builder.Add( Tables.Invoices.InvoiceNumber, dto.InvoiceNumber );
			builder.Add( Tables.Invoices.InvoiceTotal, dto.InvoiceTotal );
			builder.Add( Tables.Invoices.PaymentDate, dto.PaymentDate );
			builder.Add( Tables.Invoices.PaymentTotal, dto.PaymentTotal );
			builder.Add( Tables.Invoices.TermsID, dto.TermsId );

			_gateway.UpdateRowUsing( builder );
		}

		private IDatabaseGateway _gateway;

		private static DisplayInvoiceDto CreateFrom( DataRow row ) {
			return
				new DisplayInvoiceDto( row[ Tables.Invoices.InvoiceID.ColumnName ].ToString( ),
				                       row[ Tables.Vendors.Name.ColumnName ].ToString( ),
				                       row[ Tables.Invoices.InvoiceNumber.ColumnName ].ToString( ),
				                       row[ Tables.Invoices.InvoiceDate.ColumnName ].ToString( ),
				                       row[ Tables.Invoices.InvoiceTotal.ColumnName ].ToString( ),
				                       row[ Tables.Invoices.PaymentTotal.ColumnName ].ToString( ),
				                       row[ Tables.Invoices.CreditTotal.ColumnName ].ToString( ),
				                       row[ Tables.Terms.Description.ColumnName ].ToString( ),
				                       row[ Tables.Invoices.DueDate.ColumnName ].ToString( ),
				                       row[ Tables.Invoices.PaymentDate.ColumnName ].ToString( ) );
		}
	}
}