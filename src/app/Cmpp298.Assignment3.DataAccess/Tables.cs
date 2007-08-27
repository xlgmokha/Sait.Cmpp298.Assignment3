namespace Cmpp298.Assignment3.DataAccess {
	public sealed class Tables {
		public sealed class Invoices {
			public const string TableName = "Invoices";
			public static readonly DatabaseColumn InvoiceID = new DatabaseColumn( TableName, "InvoiceID" );
			public static readonly DatabaseColumn InvoiceNumber = new DatabaseColumn( TableName, "InvoiceNumber" );
			public static readonly DatabaseColumn InvoiceDate = new DatabaseColumn( TableName, "InvoiceDate" );
			public static readonly DatabaseColumn InvoiceTotal = new DatabaseColumn( TableName, "InvoiceTotal" );
			public static readonly DatabaseColumn PaymentTotal = new DatabaseColumn( TableName, "PaymentTotal" );
			public static readonly DatabaseColumn CreditTotal = new DatabaseColumn( TableName, "CreditTotal" );
			public static readonly DatabaseColumn DueDate = new DatabaseColumn( TableName, "DueDate" );
			public static readonly DatabaseColumn PaymentDate = new DatabaseColumn( TableName, "PaymentDate" );
			public static readonly DatabaseColumn TermsID = new DatabaseColumn( TableName, "TermsID" );
			public static readonly DatabaseColumn VendorID = new DatabaseColumn( TableName, "VendorID" );
		}

		public sealed class Vendors {
			public const string TableName = "Vendors";
			public static readonly DatabaseColumn VendorID = new DatabaseColumn( TableName, "VendorID" );
			public static readonly DatabaseColumn Name = new DatabaseColumn( TableName, "Name" );
		}

		public sealed class Terms {
			public const string TableName = "Terms";
			public static readonly DatabaseColumn TermsID = new DatabaseColumn( TableName, "TermsID" );
			public static readonly DatabaseColumn Description = new DatabaseColumn( TableName, "Description" );
			public static readonly DatabaseColumn DueDays = new DatabaseColumn( TableName, "DueDays" );
		}
	}
}