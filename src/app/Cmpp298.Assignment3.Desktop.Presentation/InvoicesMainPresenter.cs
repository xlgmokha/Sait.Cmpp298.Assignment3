using System.Collections.Generic;
using Cmpp298.Assignment3.Dto;
using Cmpp298.Assignment3.Task;

namespace Cmpp298.Assignment3.Presentation {
	public class InvoicesMainPresenter {
		private readonly IInvoiceTask _invoiceTask;
		private readonly IInvoicesMainView _view;
		private readonly IVendorTask _vendorsTask;

		public InvoicesMainPresenter( IInvoicesMainView view ) : this( view, new VendorTask( ), new InvoiceTask( ) ) {}

		public InvoicesMainPresenter( IInvoicesMainView view, IVendorTask vendorsTask, IInvoiceTask invoiceTask ) {
			_view = view;
			_vendorsTask = vendorsTask;
			_invoiceTask = invoiceTask;
		}

		public void Initialize( ) {
			_view.VendorNames.BindTo( _vendorsTask.GetAllVendorNames( ) );
		}

		public void LoadInvoices( ) {
			IDropDownListItem selectedItem = _view.VendorNames.SelectedItem;
			if ( selectedItem != null ) {
				IEnumerable< DisplayInvoiceDto > enumerable = _invoiceTask.GetAllInvoices( selectedItem.Value );
				_view.BindTo( enumerable );
			}
		}
	}
}