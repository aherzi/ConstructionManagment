namespace ConstructionAppClient
{
    partial class OwnerDashbaord
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
            this.label1 = new System.Windows.Forms.Label();
            this.cmbSite = new System.Windows.Forms.ComboBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.lblOverall = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelPie = new System.Windows.Forms.Panel();
            this.panelBar = new System.Windows.Forms.Panel();
            this.gridStatus = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gridStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Site";
            // 
            // cmbSite
            // 
            this.cmbSite.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSite.FormattingEnabled = true;
            this.cmbSite.Location = new System.Drawing.Point(140, 17);
            this.cmbSite.Name = "cmbSite";
            this.cmbSite.Size = new System.Drawing.Size(185, 33);
            this.cmbSite.TabIndex = 1;
            this.cmbSite.SelectedIndexChanged += new System.EventHandler(this.cmbSite_SelectedIndexChanged);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(460, 15);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 41);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            // 
            // lblOverall
            // 
            this.lblOverall.AutoSize = true;
            this.lblOverall.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblOverall.Location = new System.Drawing.Point(20, 65);
            this.lblOverall.Name = "lblOverall";
            this.lblOverall.Size = new System.Drawing.Size(400, 42);
            this.lblOverall.TabIndex = 3;
            this.lblOverall.Text = "Overall completion: 0%";
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatus.Location = new System.Drawing.Point(20, 116);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(136, 37);
            this.lblStatus.TabIndex = 4;
            this.lblStatus.Text = "Status: -";
            // 
            // panelPie
            // 
            this.panelPie.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelPie.Location = new System.Drawing.Point(20, 125);
            this.panelPie.Name = "panelPie";
            this.panelPie.Size = new System.Drawing.Size(300, 260);
            this.panelPie.TabIndex = 5;
            // 
            // panelBar
            // 
            this.panelBar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelBar.Location = new System.Drawing.Point(340, 125);
            this.panelBar.Name = "panelBar";
            this.panelBar.Size = new System.Drawing.Size(520, 260);
            this.panelBar.TabIndex = 6;
            // 
            // gridStatus
            // 
            this.gridStatus.AllowUserToAddRows = false;
            this.gridStatus.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.gridStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gridStatus.Location = new System.Drawing.Point(20, 395);
            this.gridStatus.Name = "gridStatus";
            this.gridStatus.ReadOnly = true;
            this.gridStatus.RowHeadersWidth = 82;
            this.gridStatus.RowTemplate.Height = 33;
            this.gridStatus.Size = new System.Drawing.Size(840, 230);
            this.gridStatus.TabIndex = 7;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 664);
            this.Controls.Add(this.gridStatus);
            this.Controls.Add(this.panelBar);
            this.Controls.Add(this.panelPie);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.lblOverall);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cmbSite);
            this.Controls.Add(this.label1);
            this.Name = "DashboardForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Owner Dashboard";
            ((System.ComponentModel.ISupportInitialize)(this.gridStatus)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbSite;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label lblOverall;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.Panel panelPie;
        private System.Windows.Forms.Panel panelBar;
        private System.Windows.Forms.DataGridView gridStatus;
    }
}