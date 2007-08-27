using System.Collections.Generic;
using Cmpp298.Assignment3.Dto;

namespace Cmpp298.Assignment3.Task {
	public interface IVendorTask {
		IEnumerable< IDropDownListItem > GetAllVendorNames( );
		DisplayVendorNameDto FindVendorNameBy( string vendorId );
	}
}