using System.Collections.Generic;
using Cmpp298.Assignment3.Dto;

namespace Cmpp298.Assignment3.Presentation {
	public interface IInvoicesMainView {
		IDropDownListAdapter VendorNames { get; }
		void BindTo( IEnumerable< DisplayInvoiceDto > invoices );
	}
}