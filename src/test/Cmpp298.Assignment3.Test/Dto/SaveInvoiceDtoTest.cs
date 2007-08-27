using Cmpp298.Assignment3.Dto;
using MbUnit.Framework;

namespace Cmpp298.Assignment3.Test.Dto {
	[TestFixture]
	public class SaveInvoiceDtoTest {
		[Test]
		public void Should_Be_Equal( ) {
			SaveInvoiceDto dto1 = new SaveInvoiceDto( "1", "QP58872", "1/5/2007 12:00:00 AM", "116.5400", "116.5400", "0.0000",
			                                          "3/4/2007 12:00:00 AM",
			                                          "2/22/2007 12:00:00 AM", "4" );

			SaveInvoiceDto dto2 = new SaveInvoiceDto( "1", "QP58872", "1/5/2007 12:00:00 AM", "116.5400", "116.5400", "0.0000",
			                                          "3/4/2007 12:00:00 AM",
			                                          "2/22/2007 12:00:00 AM", "4" );

			Assert.IsTrue( dto1.Equals( dto2 ), "Both dtos Should be equal" );
		}

		[Test]
		public void Should_Not_Be_Equal( ) {
			SaveInvoiceDto dto1 = new SaveInvoiceDto( "1", "QP58872", "1/5/2007 12:00:00 AM", "116.5400", "116.5400", "0.0000",
			                                          "3/4/2007 12:00:00 AM",
			                                          "2/22/2007 12:00:00 AM", "4" );

			SaveInvoiceDto dto2 = new SaveInvoiceDto( "2", "QP58872", "1/5/2007 12:00:00 AM", "116.5400", "116.5400", "0.0000",
			                                          "3/4/2007 12:00:00 AM",
			                                          "2/22/2007 12:00:00 AM", "4" );

			Assert.IsTrue( !dto1.Equals( dto2 ), "Both dtos Should not be equal" );
		}
	}
}