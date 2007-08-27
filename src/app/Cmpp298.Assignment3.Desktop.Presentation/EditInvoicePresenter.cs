using Cmpp298.Assignment3.Domain;
using Cmpp298.Assignment3.Dto;
using Cmpp298.Assignment3.Task;

namespace Cmpp298.Assignment3.Presentation {
	public class EditInvoicePresenter {
		private readonly string _invoiceId;
		private readonly IEditInvoiceView _view;
		private readonly IInvoiceTask _task;
		private readonly ITermTask _termTask;

		public EditInvoicePresenter( string invoiceId, IEditInvoiceView view )
			: this( invoiceId, view, new InvoiceTask( ), new TermTask( ) ) {}

		public EditInvoicePresenter( string invoiceId, IEditInvoiceView view, IInvoiceTask task, ITermTask termTask ) {
			_view = view;
			_task = task;
			_termTask = termTask;
			_invoiceId = invoiceId;
		}

		public void Initialize( ) {
			_view.TermsDropDown.BindTo( _termTask.GetAll( ) );
			UpdateViewFrom( _task.GetInvoiceBy( _invoiceId ) );
		}

		public void UpdateInvoice( ) {
			if ( IsValidInput( ) ) {
				_task.UpdateInvoice( CreateDtoFromView( ) );
			}
			else {
				_view.ShowError( "Invalid input detected" );
			}
		}

		private void UpdateViewFrom( DisplayInvoiceDto dto ) {
			_view.VendorName = dto.VendorName;
			_view.InvoiceNumber = dto.InvoiceNumber;
			_view.InvoiceDate = dto.InvoiceDate;
			_view.InvoiceTotal = dto.InvoiceTotal;
			_view.PaymentTotal = dto.PaymentTotal;
			_view.CreditTotal = dto.CreditTotal;
			_view.DueDate = dto.DueDate;
			_view.PaymentDate = dto.PaymentDate;
			_view.TermsDropDown.SetSelectedItemTo( dto.Terms );
		}

		private bool IsValidInput( ) {
			AmountEntrySpecification specification = new AmountEntrySpecification( );
			return
				specification.IsSatisfiedBy( _view.CreditTotal )
				&& specification.IsSatisfiedBy( _view.PaymentTotal )
				&& specification.IsSatisfiedBy( _view.InvoiceTotal );
		}

		private UpdateInvoiceDto CreateDtoFromView( ) {
			return
				new UpdateInvoiceDto( _invoiceId, _view.InvoiceNumber, _view.InvoiceDate, _view.InvoiceTotal, _view.PaymentTotal,
				                      _view.CreditTotal, _view.DueDate, _view.PaymentDate, _view.TermsDropDown.SelectedItem.Value );
		}
	}
}