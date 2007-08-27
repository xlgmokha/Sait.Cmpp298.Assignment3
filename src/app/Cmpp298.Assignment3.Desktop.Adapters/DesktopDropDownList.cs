/*
 * Created by: Mo
 * Created: Sunday, August 12, 2007
 */

using System.Collections.Generic;
using System.Windows.Forms;
using Cmpp298.Assignment3.Dto;

namespace Cmpp298.Assignment3.Desktop.Adapters {
	public class DesktopDropDownList : IDropDownListAdapter {
		public DesktopDropDownList( ComboBox dropDown ) {
			_dropDown = dropDown;
			_pairs = new Dictionary< string, IDropDownListItem >( );
		}

		public void BindTo( IEnumerable< IDropDownListItem > pairs ) {
			if ( pairs != null ) {
				_pairs = new Dictionary< string, IDropDownListItem >( );

				foreach ( IDropDownListItem pair in pairs ) {
					_dropDown.Items.Add( pair.Text );
					_pairs.Add( pair.Text, pair );
				}
				_dropDown.SelectedIndex = 0;
			}
		}

		public IDropDownListItem SelectedItem {
			get { return !string.IsNullOrEmpty( _dropDown.Text ) ? _pairs[ _dropDown.Text ] : null; }
		}

		public void SetSelectedItemTo( string text ) {
			_dropDown.SelectedIndex = _dropDown.Items.IndexOf( text );
		}

		private ComboBox _dropDown;
		private IDictionary< string, IDropDownListItem > _pairs;
	}
}