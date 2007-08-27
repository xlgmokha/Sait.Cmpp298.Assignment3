using System;
using System.Collections.Generic;
using Cmpp298.Assignment3.Dto;
using Cmpp298.Assignment3.Task;
using MbUnit.Framework;

namespace Cmpp298.Assignment3.Test {
	[TestFixture]
	public class InvoiceTaskTest {
		[Test]
		[RollBack]
		public void Should_Return_114( ) {
			const string forVendorId = "122";
			Assert.IsTrue( new List< DisplayInvoiceDto >( CreateSut( ).GetAllInvoices( forVendorId ) ).Count == 9 );
		}

		[Test]
		[RollBack]
		public void Should_Return_2( ) {
			const string forVendorId = "34";
			List< DisplayInvoiceDto > list = new List< DisplayInvoiceDto >( CreateSut( ).GetAllInvoices( forVendorId ) );
			Assert.IsTrue( list.Count == 2, "should equal 2 but has " + list.Count );
		}

		[Test]
		[RollBack]
		public void Should_Save_New_Invoice( ) {
			const string vendorId = "1";
			const string termsId = "1";
			SaveInvoiceDto saveInvoiceDto =
				new SaveInvoiceDto( vendorId, Guid.NewGuid( ).ToString( ),
				                    DateTime.Now.ToString( ), "123.48", "123.48", "0.00",
				                    DateTime.Now.AddDays( 1 ).ToString( ),
				                    DateTime.Now.ToString( ),
				                    termsId );
			InvoiceTask invoiceTask = CreateSut( );
			string invoiceId = invoiceTask.SaveNewInvoice( saveInvoiceDto ).ToString( );

			bool foundInvoice = false;
			foreach ( DisplayInvoiceDto displayInvoiceDto in invoiceTask.GetAllInvoices( vendorId ) ) {
				if ( displayInvoiceDto.InvoiceId == invoiceId ) {
					foundInvoice = true;
				}
			}
			Assert.IsTrue( foundInvoice, "Couldn't find the inserted invoice record" );
		}

		[Test]
		[RollBack]
		public void Should_Be_Able_To_Find_Invoice_By_Id( ) {
			InvoiceTask task = CreateSut( );
			string invoiceNumber = Guid.NewGuid( ).ToString( );
			int id = task.SaveNewInvoice(
				new SaveInvoiceDto( "34", invoiceNumber, DateTime.Today.ToString( ), "1.00", "1.00", "0.00",
				                    DateTime.Today.ToString( ),
				                    DateTime.Today.ToString( ), "1" ) );

			DisplayInvoiceDto dto = task.GetInvoiceBy( id.ToString( ) );

			Assert.IsTrue( dto.CreditTotal == "0.0000", "Credit Total Actual: " + dto.CreditTotal );
			Assert.IsTrue( dto.DueDate == DateTime.Today.ToString( ), "Due Date Actual: " + dto.DueDate );
			Assert.IsTrue( dto.InvoiceDate == DateTime.Today.ToString( ), "Invoice Date Actual: " + dto.InvoiceDate );
			Assert.IsTrue( dto.InvoiceId == id.ToString( ), "Invoice Id Actual: " + dto.InvoiceId );
			Assert.IsTrue( dto.InvoiceNumber == invoiceNumber, "Invoice Number Actual: " + dto.InvoiceNumber );
			Assert.IsTrue( dto.InvoiceTotal == "1.0000", "Invoice Total Actual: " + dto.InvoiceTotal );
			Assert.IsTrue( dto.PaymentDate == DateTime.Today.ToString( ), "Payment Date Actual: " + dto.PaymentDate );
			Assert.IsTrue( dto.PaymentTotal == "1.0000", "Payment Total Actual: " + dto.PaymentTotal );
		}

		[Test]
		[RollBack]
		public void Should_Be_Able_To_Delete_Invoice( ) {
			InvoiceTask task = CreateSut( );
			int id = task.SaveNewInvoice(
				new SaveInvoiceDto( "34", Guid.NewGuid( ).ToString( ), DateTime.Today.ToString( ), "1.00", "1.00", "0.00",
				                    DateTime.Today.ToString( ),
				                    DateTime.Today.ToString( ), "1" ) );

			task.DeleteInvoice( id.ToString( ) );
			Assert.IsTrue( task.GetInvoiceBy( id.ToString( ) ) == null );
		}

		[Test]
		[RollBack]
		public void Should_Be_Able_To_Update_Invoice_Details( ) {
			InvoiceTask task = CreateSut( );
			int id = task.SaveNewInvoice(
				new SaveInvoiceDto( "34", Guid.NewGuid( ).ToString( ), DateTime.Today.ToString( ), "1.00", "1.00", "0.00",
				                    DateTime.Today.ToString( ),
				                    DateTime.Today.ToString( ), "1" ) );

			DisplayInvoiceDto dto = task.GetInvoiceBy( id.ToString( ) );
			task.UpdateInvoice(
				new UpdateInvoiceDto( id.ToString( ), dto.InvoiceNumber, dto.InvoiceDate, dto.InvoiceTotal, "123.45",
				                      dto.CreditTotal, dto.DueDate, dto.PaymentDate, "1" ) );

			dto = task.GetInvoiceBy( id.ToString( ) );
			Assert.IsTrue( dto.PaymentTotal == "123.4500" );
		}

		private static InvoiceTask CreateSut( ) {
			return new InvoiceTask( );
		}
	}
}