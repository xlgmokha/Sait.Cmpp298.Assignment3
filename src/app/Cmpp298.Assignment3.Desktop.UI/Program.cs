using System;
using System.Windows.Forms;

namespace Cmpp298.Assignment3.Desktop.UI {
	internal static class Program {
		/// <summary>The main entry point for the application.</summary>
		[STAThread]
		private static void Main( ) {
			try {
				Application.EnableVisualStyles( );
				Application.SetCompatibleTextRenderingDefault( false );
				Application.Run( new InvoicesMainView( ) );
			}
			catch {
				MessageBox.Show( "I'm sorry but an unexpected error has occurred.", "Ooops!", MessageBoxButtons.OK,
				                 MessageBoxIcon.Error );
			}
		}
	}
}