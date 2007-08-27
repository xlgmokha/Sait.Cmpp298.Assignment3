using System;
using Cmpp298.Assignment3.Domain;
using Cmpp298.Assignment3.Dto;
using Cmpp298.Assignment3.Task;

namespace Cmpp298.Assignment3.Presentation {
	public class NewInvoicePresenter {
		private readonly string _vendorId;
		private readonly INewInvoiceView _view;
		private readonly IInvoiceTask _invoiceTask;
		private readonly IVendorTask _vendorTask;
		private readonly ITermTask _termTask;

		public NewInvoicePresenter( string vendorId, INewInvoiceView view )
			: this( vendorId, view, new InvoiceTask( ), new VendorTask( ), new TermTask( ) ) {}

		public NewInvoicePresenter( string vendorId, INewInvoiceView view, IInvoiceTask invoiceTask, IVendorTask vendorTask,
		                            ITermTask termTask ) {
			_vendorId = vendorId;
			_view = view;
			_invoiceTask = invoiceTask;
			_vendorTask = vendorTask;
			_termTask = termTask;
		}

		public void Load( ) {
			_view.BindTo( _vendorTask.FindVendorNameBy( _vendorId ) );
			_view.InvoiceNumber = Guid.NewGuid( ).ToString( );
			_view.Terms.BindTo( _termTask.GetAll( ) );
		}

		public void SaveInvoice( ) {
			if ( IsValidInput( ) ) {
				_invoiceTask.SaveNewInvoice( CreateDtoFromView( ) );
			}
			else {
				_view.ShowError( "Invalid input detected!" );
			}
		}

		private bool IsValidInput( ) {
			AmountEntrySpecification specification = new AmountEntrySpecification( );
			return
				specification.IsSatisfiedBy( _view.CreditTotal )
				&& specification.IsSatisfiedBy( _view.PaymentTotal )
				&& specification.IsSatisfiedBy( _view.InvoiceTotal );
		}

		private SaveInvoiceDto CreateDtoFromView( ) {
			return new SaveInvoiceDto( _vendorId, _view.InvoiceNumber, _view.InvoiceDate, _view.InvoiceTotal, _view.PaymentTotal,
			                           _view.CreditTotal, _view.DueDate, _view.PaymentDate, _view.Terms.SelectedItem.Value );
		}
	}
}