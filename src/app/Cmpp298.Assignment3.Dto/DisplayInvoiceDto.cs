namespace Cmpp298.Assignment3.Dto {
	public class DisplayInvoiceDto {
		public DisplayInvoiceDto( string invoiceId, string vendorName, string invoiceNumber, string invoiceDate, string invoiceTotal,
		                   string paymentTotal, string creditTotal, string terms, string dueDate, string paymentDate ) {
			_invoiceId = invoiceId;
			_vendorName = vendorName;
			_invoiceNumber = invoiceNumber;
			_invoiceDate = invoiceDate;
			_invoiceTotal = invoiceTotal;
			_paymentTotal = paymentTotal;
			_creditTotal = creditTotal;
			_terms = terms;
			_dueDate = dueDate;
			_paymentDate = paymentDate;
		}

		public string InvoiceId {
			get { return _invoiceId; }
		}

		public string VendorName {
			get { return _vendorName; }
		}

		public string InvoiceNumber {
			get { return _invoiceNumber; }
		}

		public string InvoiceDate {
			get { return _invoiceDate; }
		}

		public string InvoiceTotal {
			get { return _invoiceTotal; }
		}

		public string PaymentTotal {
			get { return _paymentTotal; }
		}

		public string CreditTotal {
			get { return _creditTotal; }
		}

		public string Terms {
			get { return _terms; }
		}

		public string DueDate {
			get { return _dueDate; }
		}

		public string PaymentDate {
			get { return _paymentDate; }
		}

		private readonly string _invoiceId;
		private readonly string _vendorName;
		private readonly string _invoiceNumber;
		private readonly string _invoiceDate;
		private readonly string _invoiceTotal;
		private readonly string _paymentTotal;
		private readonly string _creditTotal;
		private readonly string _terms;
		private readonly string _dueDate;
		private readonly string _paymentDate;
	}
}