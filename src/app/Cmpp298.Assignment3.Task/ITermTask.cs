using System.Collections.Generic;
using Cmpp298.Assignment3.Dto;

namespace Cmpp298.Assignment3.Task {
	public interface ITermTask {
		IEnumerable< IDropDownListItem > GetAll( );
	}
}