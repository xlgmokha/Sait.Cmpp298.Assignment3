using System.Collections.Generic;
using Cmpp298.Assignment3.Dto;
using Cmpp298.Assignment3.Presentation;
using Cmpp298.Assignment3.Task;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Cmpp298.Assignment3.Test.Presentation {
	[TestFixture]
	public class InvoicesMainPresenterTest {
		private MockRepository _mockery;
		private IInvoicesMainView _view;
		private IVendorTask _vendorsTask;
		private IDropDownListAdapter _vendorNamesDropDown;
		private IInvoiceTask _invoiceTask;

		[SetUp]
		public void SetUp( ) {
			_mockery = new MockRepository( );
			_view = _mockery.Stub< IInvoicesMainView >( );
			_vendorsTask = _mockery.Stub< IVendorTask >( );
			_invoiceTask = _mockery.Stub< IInvoiceTask >( );
			_vendorNamesDropDown = _mockery.Stub< IDropDownListAdapter >( );

			SetupResult.For( _view.VendorNames ).Return( _vendorNamesDropDown );
		}

		[Test]
		public void Should_Load_List_Of_Vendor_Names_On_Load( ) {
			IList< IDropDownListItem > vendors = new List< IDropDownListItem >( );
			vendors.Add( new DropDownListItem( "US Postal Service", "1" ) );
			vendors.Add( new DropDownListItem( "National Information Data Ctr", "2" ) );
			vendors.Add( new DropDownListItem( "Register of Copyrights", "3" ) );

			using ( _mockery.Record( ) ) {
				Expect.Call( _vendorsTask.GetAllVendorNames( ) ).Return( vendors ).Repeat.Once( );
				_vendorNamesDropDown.BindTo( vendors );
			}
			using ( _mockery.Playback( ) ) {
				CreateSut( ).Initialize( );
			}
		}

		[Test]
		public void Should_Load_List_Of_Invoices_For_Vendor_On_Load( ) {
			IList< DisplayInvoiceDto > invoices = new List< DisplayInvoiceDto >( );
			const string forVendorId = "1";
			invoices.Add(
				new DisplayInvoiceDto( "1", "IBM", "QP58872", "1/5/2007 12:00:00 AM", "116.54", "116.5400", "0.0000",
				                       "Net due 60 days",
				                       "3/4/2007 12:00:00 AM", "2/22/2007 12:00:00 AM" ) );

			using ( _mockery.Record( ) ) {
				SetupResult.For( _vendorNamesDropDown.SelectedItem ).Return( new DropDownListItem( "IBM", forVendorId ) );

				Expect.Call( _invoiceTask.GetAllInvoices( forVendorId ) ).Return( invoices );
				_view.BindTo( invoices );
			}
			using ( _mockery.Playback( ) ) {
				CreateSut( ).LoadInvoices( );
			}
		}

		private InvoicesMainPresenter CreateSut( ) {
			return new InvoicesMainPresenter( _view, _vendorsTask, _invoiceTask );
		}
	}
}