using System.Text.RegularExpressions;

namespace Cmpp298.Assignment3.Domain {
	public class AmountEntrySpecification : ISpecification< string > {
		public bool IsSatisfiedBy( string input ) {
			return Regex.IsMatch( input, @"(^\d*\.?\d*[0-9]+\d*$)|(^[0-9]+\d*\.\d*$)" );
		}
	}
}