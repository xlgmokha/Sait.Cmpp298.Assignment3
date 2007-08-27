namespace Cmpp298.Assignment3.Dto {
	public class DropDownListItem : IDropDownListItem {
		public DropDownListItem( string text, string value ) {
			_text = text;
			_value = value;
		}

		public string Text {
			get { return _text; }
		}

		public string Value {
			get { return _value; }
		}

		private readonly string _text;
		private readonly string _value;
	}
}