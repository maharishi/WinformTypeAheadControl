using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TypeAheadControl {
	public class TypeAheadComboItem {
		public string Id { get; set; }
		public string ItemCategory { get; set; }
		public string Description { get; set; }

		public TypeAheadComboItem( ) {

		}

		public TypeAheadComboItem( string id , string category , string description ) {
			this.Id = id;
			this.ItemCategory = category;
			this.Description = description;
		}

		public override string ToString( ) {
			return this.Description;
		}
	}
}
