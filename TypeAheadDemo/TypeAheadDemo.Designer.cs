namespace TypeAheadDemo {
	partial class TypeAheadDemo {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose( bool disposing ) {
			if ( disposing && ( components != null ) ) {
				components.Dispose( );
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent( ) {
			this.lblSearch = new System.Windows.Forms.Label();
			this.cmbSearchText = new TypeAheadControl.TypeAheadCombo();
			this.SuspendLayout();
			// 
			// lblSearch
			// 
			this.lblSearch.AutoSize = true;
			this.lblSearch.Location = new System.Drawing.Point(33, 15);
			this.lblSearch.Name = "lblSearch";
			this.lblSearch.Size = new System.Drawing.Size(41, 13);
			this.lblSearch.TabIndex = 1;
			this.lblSearch.Text = "Search";
			// 
			// cmbSearchText
			// 
			this.cmbSearchText.CurrentItem = null;
			this.cmbSearchText.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
			this.cmbSearchText.FormattingEnabled = true;
			this.cmbSearchText.Location = new System.Drawing.Point(80, 12);
			this.cmbSearchText.Name = "cmbSearchText";
			this.cmbSearchText.Size = new System.Drawing.Size(335, 21);
			this.cmbSearchText.TabIndex = 0;
			// 
			// TypeAheadDemo
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(465, 83);
			this.Controls.Add(this.lblSearch);
			this.Controls.Add(this.cmbSearchText);
			this.Name = "TypeAheadDemo";
			this.Text = "Type Ahead Demo";
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TypeAheadControl.TypeAheadCombo cmbSearchText;
		private System.Windows.Forms.Label lblSearch;
	}
}

