namespace Cmpp298.Assignment3.Dto {
	public class UpdateInvoiceDto {
		public UpdateInvoiceDto( string invoiceId, string invoiceNumber, string invoiceDate, string invoiceTotal,
		                         string paymentTotal, string creditTotal, string dueDate, string paymentDate, string termsId ) {
			_invoiceId = invoiceId;
			_invoiceNumber = invoiceNumber;
			_invoiceDate = invoiceDate;
			_invoiceTotal = invoiceTotal;
			_paymentTotal = paymentTotal;
			_creditTotal = creditTotal;
			_dueDate = dueDate;
			_paymentDate = paymentDate;
			_termsId = termsId;
		}

		public string InvoiceId {
			get { return _invoiceId; }
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
			UpdateInvoiceDto updateInvoiceDto = obj as UpdateInvoiceDto;
			if ( updateInvoiceDto == null ) {
				return false;
			}
			if ( !Equals( _invoiceId, updateInvoiceDto._invoiceId ) ) {
				return false;
			}
			if ( !Equals( _invoiceNumber, updateInvoiceDto._invoiceNumber ) ) {
				return false;
			}
			if ( !Equals( _invoiceDate, updateInvoiceDto._invoiceDate ) ) {
				return false;
			}
			if ( !Equals( _invoiceTotal, updateInvoiceDto._invoiceTotal ) ) {
				return false;
			}
			if ( !Equals( _paymentTotal, updateInvoiceDto._paymentTotal ) ) {
				return false;
			}
			if ( !Equals( _creditTotal, updateInvoiceDto._creditTotal ) ) {
				return false;
			}
			if ( !Equals( _dueDate, updateInvoiceDto._dueDate ) ) {
				return false;
			}
			if ( !Equals( _paymentDate, updateInvoiceDto._paymentDate ) ) {
				return false;
			}
			if ( !Equals( _termsId, updateInvoiceDto._termsId ) ) {
				return false;
			}
			return true;
		}

		public override int GetHashCode( ) {
			int result = _invoiceId != null ? _invoiceId.GetHashCode( ) : 0;
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

		private readonly string _invoiceId;
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