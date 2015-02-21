using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TypeAheadControl;

namespace TypeAheadDemo {
	public partial class TypeAheadDemo : Form {

		private HashSet<string> data = new HashSet<string>( new string[ ] { "Lawrence Alexander" , "Norma Wright" , "Howard Scott" , "Eugene Bryant" , "Randy Stewart" , "Alan Bell" , "Brenda Clark" , "John Hall" , "Gloria Lee" , "Ronald Price" , "Carlos Campbell" , "Raymond Torres" , "Henry Ramirez" , "Sharon Gonzalez" , "Steven Bennett" , "Catherine Jackson" , "Marilyn Gray" , "William Brown" , "Cynthia Adams" , "Rose Edwards" , "Lori Walker" , "Judy Cox" , "Jeffrey Simmons" , "Juan James" , "Eric Williams" , "Angela Roberts" , "Fred Ross" , "Larry Butler" , "Frank Murphy" , "Mary White" , "Doris Morris" , "Russell Lopez" , "Diane Peterson" , "Lisa Rogers" , "Michelle Thompson" , "Stephanie Garcia" , "Victor Rivera" , "Irene Diaz" , "Matthew Baker" , "Nancy Miller" , "Phillip Lewis" , "Philip Long" , "Dorothy Bailey" , "Kimberly Sanchez" , "Jack Parker" , "Jerry Foster" , "Theresa Cooper" , "Denise Flores" , "Wanda Collins" , "Carolyn King" , "Linda Perez" , "Martin Richardson" , "Margaret Johnson" , "Louise Allen" , "Melissa Coleman" , "Harry Patterson" , "Scott Wilson" , "Helen Thomas" , "Brandon Barnes" , "Amy Wood" , "Joan Green" , "Donald Anderson" , "Nicole Hughes" , "Andrea Morgan" , "David Gonzales" , "Mark Henderson" , "Gerald Kelly" , "Annie Perry" , "Aaron Rodriguez" , "Charles Young" , "Jimmy Howard" , "Jonathan Reed" , "Johnny Washington" , "Peter Cook" , "Beverly Phillips" , "Joseph Martinez" , "Ralph Hill" , "Ruth Jones" , "Sarah Davis" , "Benjamin Griffin" , "Joshua Martin" , "Craig Sanders" , "Arthur Mitchell" , "Harold Ward" , "Tina Smith" , "Justin Robinson" , "Karen Jenkins" , "Joe Taylor" , "Edward Nelson" , "Roy Carter" , "Christina Brooks" , "Adam Powell" , "Kathryn Evans" , "Gary Turner" , "James Hernandez" , "Mildred Moore" , "Bonnie Russell" , "Richard Watson" , "Virginia Harris" } );

		public TypeAheadDemo( ) {
			InitializeComponent( );
			cmbSearchText.OnSearch += Search;
		}

		public List<TypeAheadComboItem> Search( string text ) {
			var result = new List<TypeAheadComboItem>( );
			int cnt = 1;
			foreach ( string val in data ) {
				if ( val.Contains( text ) ) {
					result.Add( new TypeAheadComboItem( cnt.ToString( ) , string.Empty , val ) );
				}
			}
			return result;
		}
	}
}
