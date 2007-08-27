namespace Cmpp298.Assignment3.Presentation {
	public interface IDeleteInvoiceView {
		string VendorName { set; }
		string InvoiceNumber { set; }
		string InvoiceDate { set; }
		string InvoiceTotal { set; }
		string PaymentTotal { set; }
		string CreditTotal { set; }
		string DueDate { set; }
		string PaymentDate { set; }
		string Terms { set; }
	}
}