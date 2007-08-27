using System.Collections.Generic;
using System.Windows.Forms;
using Cmpp298.Assignment3.Desktop.Adapters;
using Cmpp298.Assignment3.Dto;
using Cmpp298.Assignment3.Presentation;

namespace Cmpp298.Assignment3.Desktop.UI {
	public partial class InvoicesMainView : Form, IInvoicesMainView {
		private DesktopDropDownList _vendorsDropDown;
		private InvoicesMainPresenter _presenter;

		public InvoicesMainView( ) {
			InitializeComponent( );
			_vendorsDropDown = new DesktopDropDownList( uxVendorsDropDown );
			_presenter = new InvoicesMainPresenter( this );
			_presenter.Initialize( );

			HookupEventHandlers( );
			_presenter.LoadInvoices( );
		}

		public IDropDownListAdapter VendorNames {
			get { return _vendorsDropDown; }
		}

		public void BindTo( IEnumerable< DisplayInvoiceDto > invoices ) {
			uxInvoicesGridView.DataSource = invoices;
		}

		private delegate void Callback( string invoiceId );

		private void OpenDeleteScreen( ) {
			OpenScreen( delegate( string invoiceId ) { new DeleteInvoiceView( invoiceId ).ShowDialog( ); } );
		}

		private void OpenEditScreen( ) {
			OpenScreen( delegate( string invoiceId ) { new EditInvoiceView( invoiceId ).ShowDialog( ); } );
		}

		private void OpenScreen( Callback callback ) {
			if ( uxInvoicesGridView.SelectedRows.Count == 1 ) {
				string invoiceId = uxInvoicesGridView.SelectedRows[ 0 ].Cells[ "InvoiceId" ].Value.ToString( );
				callback( invoiceId );
				_presenter.LoadInvoices( );
			}
			else {
				MessageBox.Show( "Please select a single row", "Select a Row", MessageBoxButtons.OK, MessageBoxIcon.Error );
			}
		}

		private void HookupEventHandlers( ) {
			uxNewButton.Click += delegate { OpenNewWindow( ); };
			uxEditButton.Click += delegate { OpenEditScreen( ); };
			uxDeleteButton.Click += delegate { OpenDeleteScreen( ); };
			uxRefreshButton.Click += delegate { _presenter.LoadInvoices( ); };
			uxVendorsDropDown.SelectedIndexChanged += delegate { _presenter.LoadInvoices( ); };
		}

		private void OpenNewWindow( ) {
			new NewInvoiceView( _vendorsDropDown.SelectedItem.Value ).ShowDialog( );
			_presenter.LoadInvoices( );
		}
	}
}