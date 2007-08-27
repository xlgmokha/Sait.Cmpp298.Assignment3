using System.Collections.Generic;

namespace Cmpp298.Assignment3.Dto {
	public interface IDropDownListAdapter {
		void BindTo( IEnumerable< IDropDownListItem > pairs );

		IDropDownListItem SelectedItem { get; }

		void SetSelectedItemTo( string text );
	}
}