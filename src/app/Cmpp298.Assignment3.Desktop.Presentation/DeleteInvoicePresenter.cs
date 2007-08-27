using Cmpp298.Assignment3.Dto;
using Cmpp298.Assignment3.Task;

namespace Cmpp298.Assignment3.Presentation {
	public class DeleteInvoicePresenter {
		private readonly string _invoiceId;
		private readonly IDeleteInvoiceView _view;
		private readonly IInvoiceTask _invoiceTask;

		public DeleteInvoicePresenter( string invoiceId, IDeleteInvoiceView view )
			: this( invoiceId, view, new InvoiceTask( ) ) {}

		public DeleteInvoicePresenter( string invoiceId, IDeleteInvoiceView view, IInvoiceTask invoiceTask ) {
			_invoiceId = invoiceId;
			_view = view;
			_invoiceTask = invoiceTask;
		}

		public void Initialize( ) {
			DisplayInvoiceDto dto = _invoiceTask.GetInvoiceBy( _invoiceId );
			_view.VendorName = dto.VendorName;
			_view.InvoiceNumber = dto.InvoiceNumber;
			_view.InvoiceDate = dto.InvoiceDate;
			_view.InvoiceTotal = dto.InvoiceTotal;
			_view.PaymentTotal = dto.PaymentTotal;
			_view.CreditTotal = dto.CreditTotal;
			_view.DueDate = dto.DueDate;
			_view.PaymentDate = dto.PaymentDate;
			_view.Terms = dto.Terms;
		}

		public void DeleteInvoice( ) {
			_invoiceTask.DeleteInvoice( _invoiceId );
		}
	}
}