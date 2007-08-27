using Cmpp298.Assignment3.Dto;

namespace Cmpp298.Assignment3.Presentation {
	public interface IEditInvoiceView {
		IDropDownListAdapter TermsDropDown { get; }

		string VendorName { get; set; }

		string InvoiceNumber { get; set; }

		string InvoiceDate { get; set; }

		string InvoiceTotal { get; set; }

		string PaymentTotal { get; set; }

		string CreditTotal { get; set; }

		string DueDate { get; set; }

		string PaymentDate { get; set; }

		void ShowError( string message );
	}
}