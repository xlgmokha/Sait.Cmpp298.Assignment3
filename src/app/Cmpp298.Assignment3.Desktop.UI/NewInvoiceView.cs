using System.Windows.Forms;
using Cmpp298.Assignment3.Desktop.Adapters;
using Cmpp298.Assignment3.Dto;
using Cmpp298.Assignment3.Presentation;

namespace Cmpp298.Assignment3.Desktop.UI {
	public partial class NewInvoiceView : Form, INewInvoiceView {
		private NewInvoicePresenter _presenter;
		private DesktopDropDownList _termsDropDown;

		public NewInvoiceView( string vendorId ) {
			InitializeComponent( );
			_termsDropDown = new DesktopDropDownList( uxTermsDropDownList );
			_presenter = new NewInvoicePresenter( vendorId, this );
			_presenter.Load( );
			uxCancelButton.Click += delegate { Close( ); };
			uxSaveButton.Click += delegate { SaveAndCloseScreen( ); };
		}

		public IDropDownListAdapter Terms {
			get { return _termsDropDown; }
		}

		public string InvoiceNumber {
			get { return uxInvoiceNumberTextBox.Text; }
			set { uxInvoiceNumberTextBox.Text = value; }
		}

		public string InvoiceDate {
			get { return uxInvoiceDatePicker.Value.ToString( ); }
		}

		public string InvoiceTotal {
			get { return uxInvoiceTotalTextBox.Text; }
		}

		public string PaymentTotal {
			get { return uxPaymentTotalTextBox.Text; }
		}

		public string CreditTotal {
			get { return uxCreditTotalTextBox.Text; }
		}

		public string DueDate {
			get { return uxDueDatePicker.Value.ToString( ); }
		}

		public string PaymentDate {
			get { return uxPaymentDatePicker.Value.ToString( ); }
		}

		public void ShowError( string message ) {
			MessageBox.Show( message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error );
		}

		public void BindTo( DisplayVendorNameDto displayVendorNameDto ) {
			uxVendorNameTextBox.Text = displayVendorNameDto.VendorName;
		}

		private void SaveAndCloseScreen( ) {
			_presenter.SaveInvoice( );
			Close( );
		}
	}
}