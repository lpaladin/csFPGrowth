namespace csFinalHomework
{
	partial class ItemDetailContainer
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
			if (disposing && (components != null))
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
			this.lstMain = new System.Windows.Forms.ListView();
			this.h1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.h2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.h3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
			this.panMain = new System.Windows.Forms.TableLayoutPanel();
			this.lblName = new System.Windows.Forms.Label();
			this.txtSupport = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblSupport = new System.Windows.Forms.Label();
			this.panMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// lstMain
			// 
			this.lstMain.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.h1,
            this.h2,
            this.h3});
			this.panMain.SetColumnSpan(this.lstMain, 2);
			this.lstMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lstMain.Location = new System.Drawing.Point(3, 63);
			this.lstMain.Name = "lstMain";
			this.lstMain.Size = new System.Drawing.Size(395, 201);
			this.lstMain.TabIndex = 0;
			this.lstMain.UseCompatibleStateImageBehavior = false;
			this.lstMain.View = System.Windows.Forms.View.Details;
			// 
			// h1
			// 
			this.h1.Text = "项集编号";
			// 
			// h2
			// 
			this.h2.Text = "项集";
			this.h2.Width = 255;
			// 
			// h3
			// 
			this.h3.Text = "支持度";
			// 
			// panMain
			// 
			this.panMain.ColumnCount = 2;
			this.panMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.panMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.panMain.Controls.Add(this.lblSupport, 0, 1);
			this.panMain.Controls.Add(this.txtName, 1, 0);
			this.panMain.Controls.Add(this.lblName, 0, 0);
			this.panMain.Controls.Add(this.lstMain, 0, 2);
			this.panMain.Controls.Add(this.txtSupport, 1, 1);
			this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panMain.Location = new System.Drawing.Point(0, 0);
			this.panMain.Name = "panMain";
			this.panMain.RowCount = 3;
			this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
			this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.panMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
			this.panMain.Size = new System.Drawing.Size(401, 267);
			this.panMain.TabIndex = 1;
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblName.Location = new System.Drawing.Point(3, 0);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(194, 30);
			this.lblName.TabIndex = 0;
			this.lblName.Text = "项目名";
			this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtSupport
			// 
			this.txtSupport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtSupport.Location = new System.Drawing.Point(203, 33);
			this.txtSupport.Name = "txtSupport";
			this.txtSupport.ReadOnly = true;
			this.txtSupport.Size = new System.Drawing.Size(195, 21);
			this.txtSupport.TabIndex = 1;
			this.txtSupport.Text = "0";
			// 
			// txtName
			// 
			this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
			this.txtName.Location = new System.Drawing.Point(203, 3);
			this.txtName.Name = "txtName";
			this.txtName.ReadOnly = true;
			this.txtName.Size = new System.Drawing.Size(195, 21);
			this.txtName.TabIndex = 2;
			this.txtName.Text = "0";
			// 
			// lblSupport
			// 
			this.lblSupport.AutoSize = true;
			this.lblSupport.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lblSupport.Location = new System.Drawing.Point(3, 30);
			this.lblSupport.Name = "lblSupport";
			this.lblSupport.Size = new System.Drawing.Size(194, 30);
			this.lblSupport.TabIndex = 3;
			this.lblSupport.Text = "支持度";
			this.lblSupport.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// ItemDetailContainer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(401, 267);
			this.Controls.Add(this.panMain);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
			this.Name = "ItemDetailContainer";
			this.Text = "详细信息";
			this.TopMost = true;
			this.panMain.ResumeLayout(false);
			this.panMain.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ListView lstMain;
		private System.Windows.Forms.ColumnHeader h1;
		private System.Windows.Forms.ColumnHeader h2;
		private System.Windows.Forms.ColumnHeader h3;
		private System.Windows.Forms.TableLayoutPanel panMain;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.TextBox txtSupport;
		private System.Windows.Forms.Label lblSupport;
		private System.Windows.Forms.TextBox txtName;
	}
}