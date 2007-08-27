using System.Collections.Generic;
using Cmpp298.Assignment3.Dto;
using Cmpp298.Assignment3.Presentation;
using Cmpp298.Assignment3.Task;
using MbUnit.Framework;
using Rhino.Mocks;
using Rhino.Mocks.Constraints;

namespace Cmpp298.Assignment3.Test.Presentation {
	[TestFixture]
	public class NewInvoicePresenterTest {
		private MockRepository _mockery;
		private INewInvoiceView _view;
		private IInvoiceTask _invoiceTask;
		private IVendorTask _vendorTask;
		private ITermTask _termTask;
		private IDropDownListAdapter _termsDropDown;

		[SetUp]
		public void SetUp( ) {
			_mockery = new MockRepository( );
			_view = _mockery.Stub< INewInvoiceView >( );
			_invoiceTask = _mockery.Stub< IInvoiceTask >( );
			_vendorTask = _mockery.Stub< IVendorTask >( );
			_termTask = _mockery.Stub< ITermTask >( );
			_termsDropDown = _mockery.Stub< IDropDownListAdapter >( );

			SetupResult.For( _view.Terms ).Return( _termsDropDown );
		}

		[Test]
		public void Should_Load_Vendor_Names_On_Load( ) {
			const string vendorId = "34";
			using ( _mockery.Record( ) ) {
				DisplayVendorNameDto displayVendorNameDto = new DisplayVendorNameDto( vendorId, "IBM" );
				Expect.Call( _vendorTask.FindVendorNameBy( vendorId ) ).Return( displayVendorNameDto );
				_view.BindTo( displayVendorNameDto );
			}
			using ( _mockery.Playback( ) ) {
				CreateSut( vendorId ).Load( );
			}
		}

		[Test]
		public void Should_Load_Terms_On_Load( ) {
			IList< IDropDownListItem > terms = new List< IDropDownListItem >( );
			terms.Add( new DropDownListItem( "Net due 10 days", "1" ) );
			terms.Add( new DropDownListItem( "Net due 20 days", "2" ) );
			terms.Add( new DropDownListItem( "Net due 30 days", "3" ) );
			terms.Add( new DropDownListItem( "Net due 60 days", "4" ) );
			terms.Add( new DropDownListItem( "Net due 90 days", "5" ) );

			using ( _mockery.Record( ) ) {
				Expect.Call( _termTask.GetAll( ) ).Return( terms );
				_termsDropDown.BindTo( terms );
			}
			using ( _mockery.Playback( ) ) {
				const string vendorId = "34";
				CreateSut( vendorId ).Load( );
			}
		}

		[Test]
		public void Should_Create_New_Invoice_Number_On_Load( ) {
			using ( _mockery.Record( ) ) {}
			using ( _mockery.Playback( ) ) {
				CreateSut( "34" ).Load( );
				Assert.IsTrue( _view.InvoiceNumber != null, "Invoice number should have been generated" );
			}
		}

		[Test]
		public void Should_Save_New_Invoice( ) {
			const string vendorId = "34";
			using ( _mockery.Record( ) ) {
				SetupResult.For( _view.InvoiceDate ).Return( "1/5/2007 12:00:00 AM" );
				SetupResult.For( _view.InvoiceTotal ).Return( "116.54" );
				SetupResult.For( _view.PaymentTotal ).Return( "116.54" );
				SetupResult.For( _view.CreditTotal ).Return( "0.00" );
				SetupResult.For( _view.DueDate ).Return( "3/4/2007 12:00:00 AM" );
				SetupResult.For( _view.PaymentDate ).Return( "2/22/2007 12:00:00 AM" );
				Expect.Call( _termsDropDown.SelectedItem ).Return( new DropDownListItem( "Net due 60 days", "4" ) );

				_invoiceTask.SaveNewInvoice(
					new SaveInvoiceDto( vendorId, "QP58872", "1/5/2007 12:00:00 AM", "116.5400", "116.5400", "0.0000",
					                    "3/4/2007 12:00:00 AM",
					                    "2/22/2007 12:00:00 AM", "4" ) );
			}
			using ( _mockery.Playback( ) ) {
				CreateSut( vendorId ).SaveInvoice( );
			}
		}

		[Test]
		public void Should_Check_For_Valid_Input( ) {
			const string vendorId = "34";
			using ( _mockery.Record( ) ) {
				SetupResult.For( _view.InvoiceTotal ).Return( "abcd" );
				SetupResult.For( _view.PaymentTotal ).Return( "abcd" );
				SetupResult.For( _view.CreditTotal ).Return( "abcd" );

				_view.ShowError( null );
				LastCall.Constraints( Is.NotNull( ) );
			}
			using ( _mockery.Playback( ) ) {
				CreateSut( vendorId ).SaveInvoice( );
			}
		}

		private NewInvoicePresenter CreateSut( string vendorId ) {
			return new NewInvoicePresenter( vendorId, _view, _invoiceTask, _vendorTask, _termTask );
		}
	}
}