namespace LiveSplit.ClientPlugin
{
	partial class LSClientSettings
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

		#region Component Designer generated code

		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.txtIPAddress = new System.Windows.Forms.TextBox();
			this.txtPort = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblServerStatus = new System.Windows.Forms.Label();
			this.btnConnect = new System.Windows.Forms.Button();
			this.cbAutosplit = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// txtIPAddress
			// 
			this.txtIPAddress.Location = new System.Drawing.Point(125, 33);
			this.txtIPAddress.Name = "txtIPAddress";
			this.txtIPAddress.Size = new System.Drawing.Size(147, 20);
			this.txtIPAddress.TabIndex = 0;
			// 
			// txtPort
			// 
			this.txtPort.Location = new System.Drawing.Point(125, 59);
			this.txtPort.Name = "txtPort";
			this.txtPort.Size = new System.Drawing.Size(67, 20);
			this.txtPort.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.Location = new System.Drawing.Point(10, 36);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(109, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Server IP Address";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(89, 62);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(30, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Port";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(10, 93);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(84, 13);
			this.label3.TabIndex = 4;
			this.label3.Text = "Server Status";
			// 
			// lblServerStatus
			// 
			this.lblServerStatus.AutoSize = true;
			this.lblServerStatus.Location = new System.Drawing.Point(16, 115);
			this.lblServerStatus.Name = "lblServerStatus";
			this.lblServerStatus.Size = new System.Drawing.Size(78, 13);
			this.lblServerStatus.TabIndex = 5;
			this.lblServerStatus.Text = "lblServerStatus";
			// 
			// btnConnect
			// 
			this.btnConnect.Location = new System.Drawing.Point(13, 153);
			this.btnConnect.Name = "btnConnect";
			this.btnConnect.Size = new System.Drawing.Size(122, 23);
			this.btnConnect.TabIndex = 6;
			this.btnConnect.Text = "Attempt Connection";
			this.btnConnect.UseVisualStyleBackColor = true;
			this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
			// 
			// cbAutosplit
			// 
			this.cbAutosplit.AutoSize = true;
			this.cbAutosplit.Location = new System.Drawing.Point(13, 194);
			this.cbAutosplit.Name = "cbAutosplit";
			this.cbAutosplit.Size = new System.Drawing.Size(102, 17);
			this.cbAutosplit.TabIndex = 7;
			this.cbAutosplit.Text = "Enable Autosplit";
			this.cbAutosplit.UseVisualStyleBackColor = true;
			this.cbAutosplit.CheckedChanged += new System.EventHandler(this.cbAutosplit_CheckedChanged);
			// 
			// LSClientSettings
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.Controls.Add(this.cbAutosplit);
			this.Controls.Add(this.btnConnect);
			this.Controls.Add(this.lblServerStatus);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtPort);
			this.Controls.Add(this.txtIPAddress);
			this.Name = "LSClientSettings";
			this.Size = new System.Drawing.Size(348, 309);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtIPAddress;
		private System.Windows.Forms.TextBox txtPort;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblServerStatus;
		private System.Windows.Forms.Button btnConnect;
		private System.Windows.Forms.CheckBox cbAutosplit;
	}
}
