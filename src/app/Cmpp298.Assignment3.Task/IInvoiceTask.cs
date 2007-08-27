using System.Collections.Generic;
using Cmpp298.Assignment3.Dto;

namespace Cmpp298.Assignment3.Task {
	public interface IInvoiceTask {
		int SaveNewInvoice( SaveInvoiceDto saveInvoiceDto );
		IEnumerable< DisplayInvoiceDto > GetAllInvoices( string forVendorId );
		DisplayInvoiceDto GetInvoiceBy(string invoiceId);
		void DeleteInvoice( string invoiceId );
		void UpdateInvoice( UpdateInvoiceDto dto );
	}
}