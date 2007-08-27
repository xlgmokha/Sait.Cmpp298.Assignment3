using System.Collections.Generic;
using Cmpp298.Assignment3.Dto;
using Cmpp298.Assignment3.Presentation;
using Cmpp298.Assignment3.Task;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Cmpp298.Assignment3.Test.Presentation {
	[TestFixture]
	public class EditInvoicePresenterTest {
		private MockRepository _mockery;
		private IEditInvoiceView _view;
		private IInvoiceTask _task;
		private ITermTask _termTask;
		private IDropDownListAdapter _termsDropDown;

		[SetUp]
		public void Setup( ) {
			_mockery = new MockRepository( );
			_view = _mockery.CreateMock< IEditInvoiceView >( );
			_task = _mockery.CreateMock< IInvoiceTask >( );
			_termTask = _mockery.CreateMock< ITermTask >( );
			_termsDropDown = _mockery.CreateMock< IDropDownListAdapter >( );

			SetupResult.For( _view.TermsDropDown ).Return( _termsDropDown );
		}

		[Test]
		public void Should_Load_Invoice_Details_On_Load( ) {
			const string invoiceId = "1";
			IList< IDropDownListItem > items = new List< IDropDownListItem >( );
			items.Add( new DropDownListItem( "10 days", "1" ) );

			using ( _mockery.Record( ) ) {
				Expect.Call( _task.GetInvoiceBy( invoiceId ) ).Return(
					new DisplayInvoiceDto( invoiceId, "vendor", "number", "date", "total", "paymentTotal", "creditTotal", "terms",
					                       "dueDate", "paymentDate" ) );
				Expect.Call( _termTask.GetAll( ) ).Return( items );
				_termsDropDown.BindTo( items );
				_termsDropDown.SetSelectedItemTo( "terms" );
				_view.VendorName = "vendor";
				_view.InvoiceNumber = "number";
				_view.InvoiceDate = "date";
				_view.InvoiceTotal = "total";
				_view.PaymentTotal = "paymentTotal";
				_view.CreditTotal = "creditTotal";
				_view.DueDate = "dueDate";
				_view.PaymentDate = "paymentDate";
			}

			using ( _mockery.Playback( ) ) {
				CreateSut( invoiceId ).Initialize( );
			}
		}

		[Test]
		public void Should_Update_Changes( ) {
			const string invoiceId = "2";
			using ( _mockery.Record( ) ) {
				SetupResult.For( _view.InvoiceNumber ).Return( "QP58872" );
				SetupResult.For( _view.InvoiceDate ).Return( "1/5/2007 12:00:00 AM" );
				SetupResult.For( _view.InvoiceTotal ).Return( "116.54" );
				SetupResult.For( _view.PaymentTotal ).Return( "116.54" );
				SetupResult.For( _view.CreditTotal ).Return( "0.00" );
				SetupResult.For( _view.DueDate ).Return( "3/4/2007 12:00:00 AM" );
				SetupResult.For( _view.PaymentDate ).Return( "2/22/2007 12:00:00 AM" );
				SetupResult.For( _termsDropDown.SelectedItem ).Return( new DropDownListItem( "10 days", "4" ) );

				UpdateInvoiceDto dto =
					new UpdateInvoiceDto( invoiceId, "QP58872", "1/5/2007 12:00:00 AM", "116.54", "116.54", "0.00",
					                      "3/4/2007 12:00:00 AM",
					                      "2/22/2007 12:00:00 AM", "4" );
				_task.UpdateInvoice( dto );
			}

			using ( _mockery.Playback( ) ) {
				CreateSut( invoiceId ).UpdateInvoice( );
			}
		}

		private EditInvoicePresenter CreateSut( string invoiceId ) {
			return new EditInvoicePresenter( invoiceId, _view, _task, _termTask );
		}
	}
}