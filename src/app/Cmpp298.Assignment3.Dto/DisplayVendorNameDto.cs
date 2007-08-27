namespace Cmpp298.Assignment3.Dto {
	public class DisplayVendorNameDto {
		public DisplayVendorNameDto( string vendorId, string vendorName ) {
			_vendorId = vendorId;
			_vendorName = vendorName;
		}

		public string VendorId {
			get { return _vendorId; }
		}

		public string VendorName {
			get { return _vendorName; }
		}

		private readonly string _vendorId;
		private readonly string _vendorName;
	}
}