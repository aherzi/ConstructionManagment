namespace ConstructionAppClient
{
    partial class CreateSiteForm
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
            this.lblSiteName = new System.Windows.Forms.Label();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblZoning = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblPropertyOwner = new System.Windows.Forms.Label();
            this.lblDesc = new System.Windows.Forms.Label();
            this.txtSiteName = new System.Windows.Forms.TextBox();
            this.txtSiteAddress = new System.Windows.Forms.TextBox();
            this.txtDesc = new System.Windows.Forms.TextBox();
            this.cboxZoning = new System.Windows.Forms.ComboBox();
            this.cboxOwner = new System.Windows.Forms.ComboBox();
            this.gboxSiteInfo = new System.Windows.Forms.GroupBox();
            this.dtpickerCompletion = new System.Windows.Forms.DateTimePicker();
            this.gboxProjectAssignement = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.gboxAdditionalDetails = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblRole = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.gboxSiteInfo.SuspendLayout();
            this.gboxProjectAssignement.SuspendLayout();
            this.gboxAdditionalDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSiteName
            // 
            this.lblSiteName.AutoSize = true;
            this.lblSiteName.Location = new System.Drawing.Point(20, 34);
            this.lblSiteName.Name = "lblSiteName";
            this.lblSiteName.Size = new System.Drawing.Size(102, 28);
            this.lblSiteName.TabIndex = 0;
            this.lblSiteName.Text = "Site Name";
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(366, 34);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(117, 28);
            this.lblAddress.TabIndex = 1;
            this.lblAddress.Text = "Site address";
            // 
            // lblZoning
            // 
            this.lblZoning.AutoSize = true;
            this.lblZoning.Location = new System.Drawing.Point(20, 122);
            this.lblZoning.Name = "lblZoning";
            this.lblZoning.Size = new System.Drawing.Size(74, 28);
            this.lblZoning.TabIndex = 2;
            this.lblZoning.Text = "Zoning";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(366, 122);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 28);
            this.label4.TabIndex = 3;
            this.label4.Text = "Estimated completion date";
            // 
            // lblPropertyOwner
            // 
            this.lblPropertyOwner.AutoSize = true;
            this.lblPropertyOwner.Location = new System.Drawing.Point(20, 34);
            this.lblPropertyOwner.Name = "lblPropertyOwner";
            this.lblPropertyOwner.Size = new System.Drawing.Size(150, 28);
            this.lblPropertyOwner.TabIndex = 4;
            this.lblPropertyOwner.Text = "Property Owner";
            // 
            // lblDesc
            // 
            this.lblDesc.AutoSize = true;
            this.lblDesc.Location = new System.Drawing.Point(20, 30);
            this.lblDesc.Name = "lblDesc";
            this.lblDesc.Size = new System.Drawing.Size(178, 28);
            this.lblDesc.TabIndex = 6;
            this.lblDesc.Text = "Project Description";
            // 
            // txtSiteName
            // 
            this.txtSiteName.Location = new System.Drawing.Point(20, 64);
            this.txtSiteName.Name = "txtSiteName";
            this.txtSiteName.Size = new System.Drawing.Size(322, 34);
            this.txtSiteName.TabIndex = 0;
            // 
            // txtSiteAddress
            // 
            this.txtSiteAddress.Location = new System.Drawing.Point(366, 64);
            this.txtSiteAddress.Name = "txtSiteAddress";
            this.txtSiteAddress.Size = new System.Drawing.Size(330, 34);
            this.txtSiteAddress.TabIndex = 1;
            // 
            // txtDesc
            // 
            this.txtDesc.Location = new System.Drawing.Point(20, 60);
            this.txtDesc.Multiline = true;
            this.txtDesc.Name = "txtDesc";
            this.txtDesc.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtDesc.Size = new System.Drawing.Size(676, 88);
            this.txtDesc.TabIndex = 0;
            // 
            // cboxZoning
            // 
            this.cboxZoning.FormattingEnabled = true;
            this.cboxZoning.Location = new System.Drawing.Point(20, 152);
            this.cboxZoning.Name = "cboxZoning";
            this.cboxZoning.Size = new System.Drawing.Size(322, 36);
            this.cboxZoning.TabIndex = 2;
            // 
            // cboxOwner
            // 
            this.cboxOwner.FormattingEnabled = true;
            this.cboxOwner.Location = new System.Drawing.Point(20, 64);
            this.cboxOwner.Name = "cboxOwner";
            this.cboxOwner.Size = new System.Drawing.Size(322, 36);
            this.cboxOwner.TabIndex = 0;
            // 
            // gboxSiteInfo
            // 
            this.gboxSiteInfo.BackColor = System.Drawing.Color.White;
            this.gboxSiteInfo.Controls.Add(this.dtpickerCompletion);
            this.gboxSiteInfo.Controls.Add(this.cboxZoning);
            this.gboxSiteInfo.Controls.Add(this.txtSiteAddress);
            this.gboxSiteInfo.Controls.Add(this.txtSiteName);
            this.gboxSiteInfo.Controls.Add(this.label4);
            this.gboxSiteInfo.Controls.Add(this.lblZoning);
            this.gboxSiteInfo.Controls.Add(this.lblAddress);
            this.gboxSiteInfo.Controls.Add(this.lblSiteName);
            this.gboxSiteInfo.Location = new System.Drawing.Point(42, 98);
            this.gboxSiteInfo.Name = "gboxSiteInfo";
            this.gboxSiteInfo.Padding = new System.Windows.Forms.Padding(20);
            this.gboxSiteInfo.Size = new System.Drawing.Size(716, 242);
            this.gboxSiteInfo.TabIndex = 0;
            this.gboxSiteInfo.TabStop = false;
            this.gboxSiteInfo.Text = "Site Information";
            // 
            // dtpickerCompletion
            // 
            this.dtpickerCompletion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpickerCompletion.Location = new System.Drawing.Point(366, 152);
            this.dtpickerCompletion.Name = "dtpickerCompletion";
            this.dtpickerCompletion.Size = new System.Drawing.Size(330, 34);
            this.dtpickerCompletion.TabIndex = 3;
            // 
            // gboxProjectAssignement
            // 
            this.gboxProjectAssignement.BackColor = System.Drawing.Color.White;
            this.gboxProjectAssignement.Controls.Add(this.cboxOwner);
            this.gboxProjectAssignement.Controls.Add(this.lblPropertyOwner);
            this.gboxProjectAssignement.Location = new System.Drawing.Point(42, 358);
            this.gboxProjectAssignement.Name = "gboxProjectAssignement";
            this.gboxProjectAssignement.Padding = new System.Windows.Forms.Padding(20);
            this.gboxProjectAssignement.Size = new System.Drawing.Size(716, 220);
            this.gboxProjectAssignement.TabIndex = 1;
            this.gboxProjectAssignement.TabStop = false;
            this.gboxProjectAssignement.Text = "Project Assignment";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(-184, 400);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 100);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox3";
            this.groupBox3.Visible = false;
            // 
            // gboxAdditionalDetails
            // 
            this.gboxAdditionalDetails.BackColor = System.Drawing.Color.White;
            this.gboxAdditionalDetails.Controls.Add(this.txtDesc);
            this.gboxAdditionalDetails.Controls.Add(this.lblDesc);
            this.gboxAdditionalDetails.Location = new System.Drawing.Point(42, 596);
            this.gboxAdditionalDetails.Name = "gboxAdditionalDetails";
            this.gboxAdditionalDetails.Padding = new System.Windows.Forms.Padding(20);
            this.gboxAdditionalDetails.Size = new System.Drawing.Size(716, 170);
            this.gboxAdditionalDetails.TabIndex = 2;
            this.gboxAdditionalDetails.TabStop = false;
            this.gboxAdditionalDetails.Text = "Additional Details";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.White;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCancel.Location = new System.Drawing.Point(594, 790);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(164, 42);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnCreate
            // 
            this.btnCreate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCreate.FlatAppearance.BorderSize = 0;
            this.btnCreate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCreate.ForeColor = System.Drawing.Color.White;
            this.btnCreate.Location = new System.Drawing.Point(42, 790);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(532, 42);
            this.btnCreate.TabIndex = 3;
            this.btnCreate.Text = "Create site";
            this.btnCreate.UseVisualStyleBackColor = false;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblRole
            // 
            this.lblRole.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblRole.Location = new System.Drawing.Point(620, 40);
            this.lblRole.Name = "lblRole";
            this.lblRole.Size = new System.Drawing.Size(138, 28);
            this.lblRole.TabIndex = 19;
            this.lblRole.Text = "Contractor";
            this.lblRole.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTitle
            // 
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(40, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(520, 48);
            this.lblTitle.TabIndex = 20;
            this.lblTitle.Text = "Create site";
            // 
            // CreateSiteForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(249)))), ((int)(((byte)(252)))));
            this.ClientSize = new System.Drawing.Size(800, 870);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblRole);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gboxAdditionalDetails);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.gboxProjectAssignement);
            this.Controls.Add(this.gboxSiteInfo);
            this.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "CreateSiteForm";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Create site | Construction Management";
            this.Load += new System.EventHandler(this.CreateSite_Load);
            this.gboxSiteInfo.ResumeLayout(false);
            this.gboxSiteInfo.PerformLayout();
            this.gboxProjectAssignement.ResumeLayout(false);
            this.gboxProjectAssignement.PerformLayout();
            this.gboxAdditionalDetails.ResumeLayout(false);
            this.gboxAdditionalDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblSiteName;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblZoning;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lblPropertyOwner;
        private System.Windows.Forms.Label lblDesc;
        private System.Windows.Forms.TextBox txtSiteName;
        private System.Windows.Forms.TextBox txtSiteAddress;
        private System.Windows.Forms.TextBox txtDesc;
        private System.Windows.Forms.ComboBox cboxZoning;
        private System.Windows.Forms.ComboBox cboxOwner;
        private System.Windows.Forms.GroupBox gboxSiteInfo;
        private System.Windows.Forms.GroupBox gboxProjectAssignement;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox gboxAdditionalDetails;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblRole;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.DateTimePicker dtpickerCompletion;
    }
}