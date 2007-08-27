namespace Cmpp298.Assignment3.Dto {
	public class SaveInvoiceDto {
		public SaveInvoiceDto( string vendorId, string invoiceNumber, string invoiceDate, string invoiceTotal,
		                       string paymentTotal, string creditTotal, string dueDate, string paymentDate, string termsId ) {
			_vendorId = vendorId;
			_invoiceNumber = invoiceNumber;
			_invoiceDate = invoiceDate;
			_invoiceTotal = invoiceTotal;
			_paymentTotal = paymentTotal;
			_creditTotal = creditTotal;
			_dueDate = dueDate;
			_paymentDate = paymentDate;
			_termsId = termsId;
		}

		public string VendorId {
			get { return _vendorId; }
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

		public string DueDate {
			get { return _dueDate; }
		}

		public string PaymentDate {
			get { return _paymentDate; }
		}

		public string TermsId {
			get { return _termsId; }
		}

		public override bool Equals( object obj ) {
			if ( this == obj ) {
				return true;
			}
			SaveInvoiceDto saveInvoiceDto = obj as SaveInvoiceDto;
			if ( saveInvoiceDto == null ) {
				return false;
			}
			if ( !Equals( _vendorId, saveInvoiceDto._vendorId ) ) {
				return false;
			}
			if ( !Equals( _invoiceNumber, saveInvoiceDto._invoiceNumber ) ) {
				return false;
			}
			if ( !Equals( _invoiceDate, saveInvoiceDto._invoiceDate ) ) {
				return false;
			}
			if ( !Equals( _invoiceTotal, saveInvoiceDto._invoiceTotal ) ) {
				return false;
			}
			if ( !Equals( _paymentTotal, saveInvoiceDto._paymentTotal ) ) {
				return false;
			}
			if ( !Equals( _creditTotal, saveInvoiceDto._creditTotal ) ) {
				return false;
			}
			if ( !Equals( _dueDate, saveInvoiceDto._dueDate ) ) {
				return false;
			}
			if ( !Equals( _paymentDate, saveInvoiceDto._paymentDate ) ) {
				return false;
			}
			if ( !Equals( _termsId, saveInvoiceDto._termsId ) ) {
				return false;
			}
			return true;
		}

		public override int GetHashCode( ) {
			int result = _vendorId != null ? _vendorId.GetHashCode( ) : 0;
			result = 29*result + ( _invoiceNumber != null ? _invoiceNumber.GetHashCode( ) : 0 );
			result = 29*result + ( _invoiceDate != null ? _invoiceDate.GetHashCode( ) : 0 );
			result = 29*result + ( _invoiceTotal != null ? _invoiceTotal.GetHashCode( ) : 0 );
			result = 29*result + ( _paymentTotal != null ? _paymentTotal.GetHashCode( ) : 0 );
			result = 29*result + ( _creditTotal != null ? _creditTotal.GetHashCode( ) : 0 );
			result = 29*result + ( _dueDate != null ? _dueDate.GetHashCode( ) : 0 );
			result = 29*result + ( _paymentDate != null ? _paymentDate.GetHashCode( ) : 0 );
			result = 29*result + ( _termsId != null ? _termsId.GetHashCode( ) : 0 );
			return result;
		}

		private readonly string _vendorId;
		private readonly string _invoiceNumber;
		private readonly string _invoiceDate;
		private readonly string _invoiceTotal;
		private readonly string _paymentTotal;
		private readonly string _creditTotal;
		private readonly string _dueDate;
		private readonly string _paymentDate;
		private readonly string _termsId;
	}
}