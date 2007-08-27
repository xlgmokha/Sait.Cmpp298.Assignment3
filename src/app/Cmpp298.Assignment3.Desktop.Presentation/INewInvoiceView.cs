using Cmpp298.Assignment3.Dto;

namespace Cmpp298.Assignment3.Presentation {
	public interface INewInvoiceView {
		void BindTo( DisplayVendorNameDto displayVendorNameDto );

		IDropDownListAdapter Terms { get; }

		string InvoiceNumber { get; set; }

		string InvoiceDate { get; }

		string InvoiceTotal { get; }

		string PaymentTotal { get; }

		string CreditTotal { get; }

		string DueDate { get; }

		string PaymentDate { get; }

		void ShowError( string message );
	}
}