namespace csFinalHomework
{
	partial class Visualizer<T>
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
			this.grpSettings = new System.Windows.Forms.GroupBox();
			this.numTopX = new System.Windows.Forms.NumericUpDown();
			this.lblTopX2 = new System.Windows.Forms.Label();
			this.lblTopX = new System.Windows.Forms.Label();
			this.btnBorderColor = new System.Windows.Forms.Button();
			this.btnHighLightColor = new System.Windows.Forms.Button();
			this.btnLineColor = new System.Windows.Forms.Button();
			this.dlgColor = new System.Windows.Forms.ColorDialog();
			this.tagCloud = new csFinalHomework.TagCloud();
			this.lblHint = new System.Windows.Forms.Label();
			this.grpSettings.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTopX)).BeginInit();
			this.SuspendLayout();
			// 
			// grpSettings
			// 
			this.grpSettings.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.grpSettings.Controls.Add(this.btnLineColor);
			this.grpSettings.Controls.Add(this.btnHighLightColor);
			this.grpSettings.Controls.Add(this.btnBorderColor);
			this.grpSettings.Controls.Add(this.numTopX);
			this.grpSettings.Controls.Add(this.lblTopX2);
			this.grpSettings.Controls.Add(this.lblTopX);
			this.grpSettings.Location = new System.Drawing.Point(12, 243);
			this.grpSettings.Name = "grpSettings";
			this.grpSettings.Size = new System.Drawing.Size(260, 87);
			this.grpSettings.TabIndex = 1;
			this.grpSettings.TabStop = false;
			this.grpSettings.Text = "设置";
			// 
			// numTopX
			// 
			this.numTopX.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.numTopX.Location = new System.Drawing.Point(88, 21);
			this.numTopX.Name = "numTopX";
			this.numTopX.Size = new System.Drawing.Size(74, 21);
			this.numTopX.TabIndex = 1;
			this.numTopX.ValueChanged += new System.EventHandler(this.numTopX_ValueChanged);
			// 
			// lblTopX2
			// 
			this.lblTopX2.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblTopX2.AutoSize = true;
			this.lblTopX2.Location = new System.Drawing.Point(168, 23);
			this.lblTopX2.Name = "lblTopX2";
			this.lblTopX2.Size = new System.Drawing.Size(65, 12);
			this.lblTopX2.TabIndex = 0;
			this.lblTopX2.Text = "个频繁项集";
			// 
			// lblTopX
			// 
			this.lblTopX.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.lblTopX.AutoSize = true;
			this.lblTopX.Location = new System.Drawing.Point(41, 23);
			this.lblTopX.Name = "lblTopX";
			this.lblTopX.Size = new System.Drawing.Size(41, 12);
			this.lblTopX.TabIndex = 0;
			this.lblTopX.Text = "显示前";
			// 
			// btnBorderColor
			// 
			this.btnBorderColor.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnBorderColor.Location = new System.Drawing.Point(7, 58);
			this.btnBorderColor.Name = "btnBorderColor";
			this.btnBorderColor.Size = new System.Drawing.Size(75, 23);
			this.btnBorderColor.TabIndex = 2;
			this.btnBorderColor.Text = "边框颜色";
			this.btnBorderColor.UseVisualStyleBackColor = true;
			this.btnBorderColor.Click += new System.EventHandler(this.btnBorderColor_Click);
			// 
			// btnHighLightColor
			// 
			this.btnHighLightColor.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnHighLightColor.Location = new System.Drawing.Point(93, 58);
			this.btnHighLightColor.Name = "btnHighLightColor";
			this.btnHighLightColor.Size = new System.Drawing.Size(75, 23);
			this.btnHighLightColor.TabIndex = 2;
			this.btnHighLightColor.Text = "高亮颜色";
			this.btnHighLightColor.UseVisualStyleBackColor = true;
			this.btnHighLightColor.Click += new System.EventHandler(this.btnHighLightColor_Click);
			// 
			// btnLineColor
			// 
			this.btnLineColor.Anchor = System.Windows.Forms.AnchorStyles.None;
			this.btnLineColor.Location = new System.Drawing.Point(179, 58);
			this.btnLineColor.Name = "btnLineColor";
			this.btnLineColor.Size = new System.Drawing.Size(75, 23);
			this.btnLineColor.TabIndex = 2;
			this.btnLineColor.Text = "线颜色";
			this.btnLineColor.UseVisualStyleBackColor = true;
			this.btnLineColor.Click += new System.EventHandler(this.btnLineColor_Click);
			// 
			// dlgColor
			// 
			this.dlgColor.AnyColor = true;
			this.dlgColor.FullOpen = true;
			// 
			// tagCloud
			// 
			this.tagCloud.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.tagCloud.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
			this.tagCloud.ForeColor = System.Drawing.Color.Blue;
			this.tagCloud.Location = new System.Drawing.Point(12, 12);
			this.tagCloud.Name = "tagCloud";
			this.tagCloud.NeedUpdate = false;
			this.tagCloud.Scale = 0;
			this.tagCloud.Size = new System.Drawing.Size(260, 225);
			this.tagCloud.TabIndex = 0;
			this.tagCloud.ItemSelected += new System.Windows.Forms.MouseEventHandler(this.tagCloud_ItemSelected);
			// 
			// lblHint
			// 
			this.lblHint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblHint.AutoSize = true;
			this.lblHint.Location = new System.Drawing.Point(10, 339);
			this.lblHint.Name = "lblHint";
			this.lblHint.Size = new System.Drawing.Size(209, 12);
			this.lblHint.TabIndex = 2;
			this.lblHint.Text = "提示：点击项目可以查看项的关联信息";
			// 
			// Visualizer
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 360);
			this.Controls.Add(this.lblHint);
			this.Controls.Add(this.grpSettings);
			this.Controls.Add(this.tagCloud);
			this.Name = "Visualizer";
			this.ShowIcon = false;
			this.Text = "频繁项集可视化";
			this.Load += new System.EventHandler(this.Visualizer_Load);
			this.grpSettings.ResumeLayout(false);
			this.grpSettings.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.numTopX)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private TagCloud tagCloud;
		private System.Windows.Forms.GroupBox grpSettings;
		private System.Windows.Forms.NumericUpDown numTopX;
		private System.Windows.Forms.Label lblTopX2;
		private System.Windows.Forms.Label lblTopX;
		private System.Windows.Forms.Button btnLineColor;
		private System.Windows.Forms.Button btnHighLightColor;
		private System.Windows.Forms.Button btnBorderColor;
		private System.Windows.Forms.ColorDialog dlgColor;
		private System.Windows.Forms.Label lblHint;
	}
}