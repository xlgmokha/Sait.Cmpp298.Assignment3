using System.Collections.Generic;
using Cmpp298.Assignment3.Dto;
using Cmpp298.Assignment3.Task;
using MbUnit.Framework;

namespace Cmpp298.Assignment3.Test {
	[TestFixture]
	public class VendorTaskTest {
		[Test]
		public void Should_Be_Able_To_Find_Vendor_By_Id( ) {
			IVendorTask task = CreateSut( );
			const string vendorId = "1";
			DisplayVendorNameDto dto = task.FindVendorNameBy( vendorId );
			Assert.IsTrue( dto.VendorId == vendorId );
			Assert.IsTrue( dto.VendorName == "US Postal Service" );
		}

		[Test]
		public void Should_Be_Able_To_Get_All_Vendor_Names( ) {
			IVendorTask task = CreateSut( );
			IList< IDropDownListItem > list = new List< IDropDownListItem >( task.GetAllVendorNames( ) );
			Assert.IsTrue( list.Count > 0, "Should have at least 1 vendor name but has: " + list.Count );
		}

		private static IVendorTask CreateSut( ) {
			return new VendorTask( );
		}
	}
}