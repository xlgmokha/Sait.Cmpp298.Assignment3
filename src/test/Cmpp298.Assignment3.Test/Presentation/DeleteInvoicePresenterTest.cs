using Cmpp298.Assignment3.Dto;
using Cmpp298.Assignment3.Presentation;
using Cmpp298.Assignment3.Task;
using MbUnit.Framework;
using Rhino.Mocks;

namespace Cmpp298.Assignment3.Test.Presentation {
	[TestFixture]
	public class DeleteInvoicePresenterTest {
		private MockRepository _mockery;
		private IDeleteInvoiceView _view;
		private IInvoiceTask _invoiceTask;

		[SetUp]
		public void SetUp( ) {
			_mockery = new MockRepository( );
			_view = _mockery.Stub< IDeleteInvoiceView >( );
			_invoiceTask = _mockery.Stub< IInvoiceTask >( );
		}

		[Test]
		public void Should_Load_Invoice_Details_On_Load( ) {
			string invoiceId = "1";
			using ( _mockery.Record( ) ) {
				Expect.Call( _invoiceTask.GetInvoiceBy( invoiceId ) ).Return(
					new DisplayInvoiceDto( invoiceId, "IBM", "12", "date", "total", "12.12", "12.12", "10 days", "due date",
					                       "payment date" ) );

				_view.VendorName = "IBM";
				_view.InvoiceNumber = "12";
				_view.InvoiceDate = "date";
				_view.InvoiceTotal = "total";
				_view.PaymentTotal = "12.12";
				_view.CreditTotal = "12.12";
				_view.DueDate = "due date";
				_view.PaymentDate = "payment date";
				_view.Terms = "10 days";
			}
			using ( _mockery.Playback( ) ) {
				CreateSut( invoiceId ).Initialize( );
			}
		}

		[Test]
		public void Should_Delete_Invoice_On_Delete_Click( ) {
			const string invoiceId = "1";
			using ( _mockery.Record( ) ) {
				_invoiceTask.DeleteInvoice( invoiceId );
			}
			using ( _mockery.Playback( ) ) {
				CreateSut( invoiceId ).DeleteInvoice( );
			}
		}

		private DeleteInvoicePresenter CreateSut( string invoiceId ) {
			return new DeleteInvoicePresenter( invoiceId, _view, _invoiceTask );
		}
	}
}