using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;

namespace TypeAheadControl {
	public delegate List<TypeAheadComboItem> TypeAheadSearch( string text );

	public partial class TypeAheadCombo : ComboBox {

		//Minimum lenght of the string to type to start search
		private const int MIN_TEXT_LENGTH_TO_START_SEARCH = 1;

		//  Wait for user-pause before searching
		private System.Timers.Timer timer = new System.Timers.Timer( );

		//  Tracks whether to kick-off Search
		private Boolean isSearchSelected = false;

		/// <summary>
		/// User-defined Search implementation.
		/// Delegate takes Search String and returns a List of TypeAheadComboItem 
		/// </summary>
		public TypeAheadSearch OnSearch;

		/// <summary>
		/// Gets / Sets Combo Item. Set will clear the existing Item List.
		/// </summary>
		public TypeAheadComboItem CurrentItem {
			get { return this.Items.Count == 0 ? null : this.SelectedItem as TypeAheadComboItem; }
			set {
				this.isSearchSelected = true;
				this.Items.Clear( );
				if ( value != null ) {
					this.Items.Add( value );
					this.SelectedIndex = 0;
				} else {
					this.Text = string.Empty;
				}
			}
		}

		public TypeAheadCombo( ) {
			InitializeComponent( );
			Initialize( );
		}

		private void Initialize( ) {
			this.DrawMode = DrawMode.OwnerDrawVariable;
			this.DrawItem += new DrawItemEventHandler( this_DrawItem );
			this.KeyPress += new KeyPressEventHandler( this_KeyPress );
			this.KeyUp += new KeyEventHandler( this_KeyUp );
			this.SelectionChangeCommitted += new EventHandler( this_SelectionChangeCommitted );
			this.TextChanged += new EventHandler( this_TextChanged );

			//Timer setting to allow the search to be triggered once the user stops typing
			this.timer.Enabled = false;
			this.timer.AutoReset = false;
			this.timer.Interval = 300;
			this.timer.Elapsed += new ElapsedEventHandler( timer_Tick );
		}

		private void this_DrawItem( object sender , DrawItemEventArgs e ) {
			if ( e.Index != -1 ) {
				TypeAheadComboItem se = this.Items[ e.Index ] as TypeAheadComboItem;

				e.DrawBackground( );

				if ( se != null )
					e.Graphics.DrawString( se.Description , this.Font , Brushes.Black , new RectangleF( e.Bounds.X + 2 , e.Bounds.Y , e.Bounds.Width , e.Bounds.Height ) );

				e.DrawFocusRectangle( );
			}
		}

		private void this_KeyPress( object sender , KeyPressEventArgs e ) {
			this.isSearchSelected = false;
		}

		private void this_KeyUp( object sender , KeyEventArgs e ) {
			if ( e.KeyCode == Keys.Up || e.KeyCode == Keys.Down )
				this.isSearchSelected = false;
		}

		private void this_SelectionChangeCommitted( object sender , EventArgs e ) {
			this.isSearchSelected = true;
		}

		private void this_TextChanged( object sender , EventArgs e ) {
			this.timer.Stop( );

			if ( !this.isSearchSelected ) {
				if ( this.Text.Length > MIN_TEXT_LENGTH_TO_START_SEARCH )
					this.timer.Start( );
				else
					this.ResetSearch( );
			}
		}

		private void timer_Tick( object sender , ElapsedEventArgs e ) {
			this.SafeInvoke( this.InitSearch );
		}

		private void InitSearch( ) {
			if ( this.DroppedDown )
				return;

			if ( this.OnSearch == null )
				throw new Exception( "No Search Implementation Configured" );

			List<TypeAheadComboItem> res = this.OnSearch( this.Text.Trim( ) );

			this.Items.Clear( );
			this.Items.AddRange( res.ToArray( ) );

			this.DroppedDown = true;
			this.Select( this.Text.Length , 0 );

			Cursor.Current = Cursors.Default;
		}

		private void ResetSearch( ) {
			this.Items.Clear( );
			this.Select( this.Text.Length , 0 );
			Cursor.Current = Cursors.Default;
		}
	}
}