namespace Cmpp298.Assignment3.Desktop.UI
{
	public partial class InvoicesMainView
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if ( disposing && ( components != null ) )
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.uxVendorsDropDown = new System.Windows.Forms.ComboBox();
			this.uxInvoicesGridView = new System.Windows.Forms.DataGridView();
			this.uxNewButton = new System.Windows.Forms.Button();
			this.uxEditButton = new System.Windows.Forms.Button();
			this.uxDeleteButton = new System.Windows.Forms.Button();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.uxRefreshButton = new System.Windows.Forms.Button();
			( (System.ComponentModel.ISupportInitialize)( this.uxInvoicesGridView ) ).BeginInit();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(13, 14);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(44, 13);
			this.label1.TabIndex = 0;
			this.label1.Text = "Vendor:";
			// 
			// uxVendorsDropDown
			// 
			this.uxVendorsDropDown.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.uxVendorsDropDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.uxVendorsDropDown.FormattingEnabled = true;
			this.uxVendorsDropDown.Location = new System.Drawing.Point(75, 23);
			this.uxVendorsDropDown.Name = "uxVendorsDropDown";
			this.uxVendorsDropDown.Size = new System.Drawing.Size(413, 21);
			this.uxVendorsDropDown.TabIndex = 1;
			// 
			// uxInvoicesGridView
			// 
			this.uxInvoicesGridView.AllowUserToAddRows = false;
			this.uxInvoicesGridView.AllowUserToDeleteRows = false;
			this.uxInvoicesGridView.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.uxInvoicesGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.uxInvoicesGridView.Location = new System.Drawing.Point(18, 50);
			this.uxInvoicesGridView.Name = "uxInvoicesGridView";
			this.uxInvoicesGridView.ReadOnly = true;
			this.uxInvoicesGridView.Size = new System.Drawing.Size(551, 354);
			this.uxInvoicesGridView.TabIndex = 2;
			// 
			// uxNewButton
			// 
			this.uxNewButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.uxNewButton.Location = new System.Drawing.Point(320, 398);
			this.uxNewButton.Name = "uxNewButton";
			this.uxNewButton.Size = new System.Drawing.Size(75, 23);
			this.uxNewButton.TabIndex = 3;
			this.uxNewButton.Text = "&New...";
			this.uxNewButton.UseVisualStyleBackColor = true;
			// 
			// uxEditButton
			// 
			this.uxEditButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.uxEditButton.Location = new System.Drawing.Point(401, 398);
			this.uxEditButton.Name = "uxEditButton";
			this.uxEditButton.Size = new System.Drawing.Size(75, 23);
			this.uxEditButton.TabIndex = 4;
			this.uxEditButton.Text = "&Edit...";
			this.uxEditButton.UseVisualStyleBackColor = true;
			// 
			// uxDeleteButton
			// 
			this.uxDeleteButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.uxDeleteButton.Location = new System.Drawing.Point(482, 398);
			this.uxDeleteButton.Name = "uxDeleteButton";
			this.uxDeleteButton.Size = new System.Drawing.Size(75, 23);
			this.uxDeleteButton.TabIndex = 5;
			this.uxDeleteButton.Text = "&Delete...";
			this.uxDeleteButton.UseVisualStyleBackColor = true;
			// 
			// groupBox1
			// 
			this.groupBox1.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( ( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom )
						| System.Windows.Forms.AnchorStyles.Left )
						| System.Windows.Forms.AnchorStyles.Right ) ) );
			this.groupBox1.Controls.Add(this.uxRefreshButton);
			this.groupBox1.Controls.Add(this.uxNewButton);
			this.groupBox1.Controls.Add(this.uxEditButton);
			this.groupBox1.Controls.Add(this.uxDeleteButton);
			this.groupBox1.Controls.Add(this.label1);
			this.groupBox1.Location = new System.Drawing.Point(12, 12);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(563, 427);
			this.groupBox1.TabIndex = 6;
			this.groupBox1.TabStop = false;
			// 
			// uxRefreshButton
			// 
			this.uxRefreshButton.Anchor = ( (System.Windows.Forms.AnchorStyles)( ( System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right ) ) );
			this.uxRefreshButton.Location = new System.Drawing.Point(482, 11);
			this.uxRefreshButton.Name = "uxRefreshButton";
			this.uxRefreshButton.Size = new System.Drawing.Size(75, 23);
			this.uxRefreshButton.TabIndex = 6;
			this.uxRefreshButton.Text = "&Refresh";
			this.uxRefreshButton.UseVisualStyleBackColor = true;
			// 
			// InvoicesMainView
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(587, 451);
			this.Controls.Add(this.uxInvoicesGridView);
			this.Controls.Add(this.uxVendorsDropDown);
			this.Controls.Add(this.groupBox1);
			this.Name = "InvoicesMainView";
			this.Text = "InvoicesMainView";
			( (System.ComponentModel.ISupportInitialize)( this.uxInvoicesGridView ) ).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox uxVendorsDropDown;
		private System.Windows.Forms.DataGridView uxInvoicesGridView;
		private System.Windows.Forms.Button uxNewButton;
		private System.Windows.Forms.Button uxEditButton;
		private System.Windows.Forms.Button uxDeleteButton;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button uxRefreshButton;
	}
}

