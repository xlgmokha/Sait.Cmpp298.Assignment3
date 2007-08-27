using System;
using System.Windows.Forms;
using Cmpp298.Assignment3.Desktop.Adapters;
using Cmpp298.Assignment3.Dto;
using Cmpp298.Assignment3.Presentation;

namespace Cmpp298.Assignment3.Desktop.UI {
	public partial class EditInvoiceView : Form, IEditInvoiceView {
		private DesktopDropDownList _termsDropDown;
		private EditInvoicePresenter _presenter;

		public EditInvoiceView( string invoiceId ) {
			InitializeComponent( );

			_termsDropDown = new DesktopDropDownList( uxTermsDropDownList );
			_presenter = new EditInvoicePresenter( invoiceId, this );

			uxUpdateButton.Click += delegate { UpdateAndCloseWindow( ); };
			uxCancelButton.Click += delegate { Close( ); };

			_presenter.Initialize( );
		}

		public IDropDownListAdapter TermsDropDown {
			get { return _termsDropDown; }
		}

		public string VendorName {
			get { return uxVendorNameTextBox.Text; }
			set { uxVendorNameTextBox.Text = value; }
		}

		public string InvoiceNumber {
			get { return uxInvoiceNumberTextBox.Text; }
			set { uxInvoiceNumberTextBox.Text = value; }
		}

		public string InvoiceDate {
			get { return uxInvoiceDatePicker.Value.ToString( ); }
			set { uxInvoiceDatePicker.Value = Convert.ToDateTime( value ); }
		}

		public string InvoiceTotal {
			get { return uxInvoiceTotalTextBox.Text; }
			set { uxInvoiceTotalTextBox.Text = value; }
		}

		public string PaymentTotal {
			get { return uxPaymentTotalTextBox.Text; }
			set { uxPaymentTotalTextBox.Text = value; }
		}

		public string CreditTotal {
			get { return uxCreditTotalTextBox.Text; }
			set { uxCreditTotalTextBox.Text = value; }
		}

		public string DueDate {
			get { return uxDueDatePicker.Value.ToString( ); }
			set { uxDueDatePicker.Value = Convert.ToDateTime( value ); }
		}

		public string PaymentDate {
			get { return uxPaymentDatePicker.Value.ToString( ); }
			set { uxPaymentDatePicker.Value = Convert.ToDateTime( value ); }
		}

		public void ShowError( string message ) {
			MessageBox.Show( message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error );
		}

		private void UpdateAndCloseWindow( ) {
			_presenter.UpdateInvoice( );
			Close( );
		}
	}
}