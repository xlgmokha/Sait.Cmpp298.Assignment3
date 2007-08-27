using System.Windows.Forms;
using Cmpp298.Assignment3.Presentation;

namespace Cmpp298.Assignment3.Desktop.UI {
	public partial class DeleteInvoiceView : Form, IDeleteInvoiceView {
		private DeleteInvoicePresenter _presenter;

		public DeleteInvoiceView( string invoiceId ) {
			InitializeComponent( );
			_presenter = new DeleteInvoicePresenter( invoiceId, this );

			uxCancelButton.Click += delegate { Close( ); };
			uxDeleteButton.Click += delegate { DeleteAndCloseWindow( ); };

			_presenter.Initialize( );
		}

		public string VendorName {
			set { uxVendorNameTextBox.Text = value; }
		}

		public string InvoiceNumber {
			set { uxInvoiceNumberTextBox.Text = value; }
		}

		public string InvoiceDate {
			set { uxInvoiceDateTextBox.Text = value; }
		}

		public string InvoiceTotal {
			set { uxInvoiceTotalTextBox.Text = value; }
		}

		public string PaymentTotal {
			set { uxPaymentTotalTextBox.Text = value; }
		}

		public string CreditTotal {
			set { uxCreditTotalTextBox.Text = value; }
		}

		public string DueDate {
			set { uxDueDateTextBox.Text = value; }
		}

		public string PaymentDate {
			set { uxPaymentDateTextBox.Text = value; }
		}

		public string Terms {
			set { uxTermsTextBox.Text = value; }
		}

		private void DeleteAndCloseWindow( ) {
			_presenter.DeleteInvoice( );
			Close( );
		}
	}
}